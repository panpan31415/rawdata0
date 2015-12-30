using DAL;
using DAL.Rewrittable;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public abstract class Repository<T> : IRepository<T> where T : class, IIdentityField
	{
		public IDataMapper<T> DataMapper { get; set; }
		public IUpdatableDataMapper<T> UpdatableDataMapper { get; set; }
		private DataMapper<T> _dataMapper;
		public Repository(IDataMapper<T> dataMapper)
		{
			DataMapper = dataMapper;
			_dataMapper = MapperSelector();
		}
		public Repository(IUpdatableDataMapper<T> updatabledatamapper)
		{
			UpdatableDataMapper = updatabledatamapper;
			_dataMapper = MapperSelector();
		}
		public T GetById(int id)
		{
			return _dataMapper.GetById(id);
		}

		public IEnumerable<T> GetAllQuestionsByKey(string key, int limit = 10, int offset = 0)
		{
			string[] stringSeparators = new string[] { " ", "," };
			string[] words = key.Split(stringSeparators, StringSplitOptions.None);
			string[] parsedWords = words.Select(word => "'%" + word + "%'").ToArray();
			var sqlWhere = "WHERE body like " + parsedWords[0];
			var w_list = new List<string>(parsedWords);
			w_list.RemoveAt(0);
			parsedWords = w_list.Select(word => "AND body like " + word).ToArray();

			var sql = string.Format("SELECT ID, {0} FROM {1} {2} {5} LIMIT {3} OFFSET {4}",
					string.Join(", ", _dataMapper.Attributes),
					_dataMapper.TableName,
					sqlWhere,
					limit,
					offset,
					string.Join(" ", parsedWords)
			);
			return _dataMapper.Query(new MySqlCommand(sql));
		}

		public IEnumerable<T> GetByKeyWords(string key, string column, int limit = 10, int offset = 0)
		{
			string[] stringSeparators = new string[] { " ", "," };
			string[] words = key.Split(stringSeparators, StringSplitOptions.None);
			string[] parsedWords = words.Select(word => "'%" + word + "%'").ToArray();
			var sqlWhere = "WHERE " + column + " like " + parsedWords[0];
			var w_list = new List<string>(parsedWords);
			w_list.RemoveAt(0);
			parsedWords = w_list.Select(word => "AND " + column + " like " + word).ToArray();

			var sql = string.Format("SELECT ID, {0} FROM {1} {2} {5} LIMIT {3} OFFSET {4}",
					string.Join(", ", _dataMapper.Attributes),
					_dataMapper.TableName,
					sqlWhere,
					limit,
					offset,
					string.Join(" ", parsedWords)
			);
			return _dataMapper.Query(new MySqlCommand(sql));
		}

		public IEnumerable<T> GetAll(int limit = 10, int offset = 0)
		{
				var sql = string.Format("SELECT ID, {0} FROM {1} LIMIT {2} OFFSET {3}",
					string.Join(", ", _dataMapper.Attributes),
					_dataMapper.TableName,
					limit,
					offset);
				return _dataMapper.Query(new MySqlCommand(sql));
			
		}
		public IEnumerable<T> GetAll(int uid, int limit = 10, int offset = 0)
		{

			var sql = string.Format("SELECT ID, {0} FROM {1} where userId = {4} LIMIT {2} OFFSET {3}",
				string.Join(", ", _dataMapper.Attributes),
				_dataMapper.TableName,
				limit,
				offset,
				uid);
			return _dataMapper.Query(new MySqlCommand(sql));

		}

		public IEnumerable<T> GetByPost(int postid, int limit = 10, int offset = 0)
		{
				var sql = string.Format("SELECT ID, {0} FROM {1} WHERE postId={4} LIMIT {2} OFFSET {3} ",
				string.Join(", ", _dataMapper.Attributes),
				_dataMapper.TableName,
				limit,
				offset,
				postid);
				return _dataMapper.Query(new MySqlCommand(sql));
		}

		public IEnumerable<T> GetByUserId(int userid, int limit = 10, int offset = 0)
		{

			var sql = string.Format("SELECT ID, {0} FROM {1} WHERE userId={4} LIMIT {2} OFFSET {3} ",
			string.Join(", ", _dataMapper.Attributes),
			_dataMapper.TableName,
			limit,
			offset,
			userid);
			return _dataMapper.Query(new MySqlCommand(sql));

		}

		public IEnumerable<T> GetAllQuestions(int limit, int offset)
		{
			var sql = string.Format("SELECT ID, {0} FROM {1} WHERE postTypeID=1 order by creationDate DESC LIMIT {2} OFFSET {3}  ",
				string.Join(", ", _dataMapper.Attributes),
				_dataMapper.TableName,
				limit,
				offset);
			return _dataMapper.Query(new MySqlCommand(sql));
		}
		public IEnumerable<T> GetAllAnswers(int qid, int limit = 10, int offset = 0)
		{
			var sql = string.Format("SELECT ID, {0} FROM {1} WHERE postTypeID=2 AND parentQuestionID={4} LIMIT {2} OFFSET {3} ",
				string.Join(", ", _dataMapper.Attributes),
				_dataMapper.TableName,
				limit,
				offset,
				qid);
			return _dataMapper.Query(new MySqlCommand(sql));
		}
		/// <summary>
		/// a search solution use full text search 
		/// </summary>
		/// <param name="searchText">the text received from searchbox </param>
		/// <param name="columns">the column in database</param>
		/// <param name="limit">the records number that will be returned</param>
		/// <param name="offset">start point resultset</param>
		/// <param name="orderby">the column that is used to be ordered by</param>
		/// <param name="ASC_DESC">ordering method</param>
		/// <returns></returns>
		public virtual IEnumerable<T> GetByFullTextSearch(string searchText, string columns, int limit = 10, int offset = 0, string orderby = "relevance", string ASC_DESC = "DESC")
		{
			var condition = "where match (" + columns + ") " + "against( '" + searchText + "') ORDER BY " + orderby + " " + ASC_DESC;
			var sql = string.Format("SELECT ID, {0}{1} FROM {2} {3} limit {4} offset {5} ",
				string.Join(", ", _dataMapper.Attributes),
				",match (" + columns + ")" + "against ('" + searchText + "') AS relevance",
				_dataMapper.TableName,
				condition,
				limit,
				offset
				);
			return _dataMapper.Query(new MySqlCommand(sql));
		}
		public IEnumerable<T> GetByKeyWords(string key, string column, int UserID, int limit = 10, int offset = 0)
		{
			string[] stringSeparators = new string[] { " ", "," };
			string[] words = key.Split(stringSeparators, StringSplitOptions.None);
			string[] parsedWords = words.Select(word => "'%" + word + "%'").ToArray();
			var sqlWhere = "WHERE " + column + " like " + parsedWords[0];
			var w_list = new List<string>(parsedWords);
			w_list.RemoveAt(0);
			parsedWords = w_list.Select(word => "AND " + column + " like " + word).ToArray();
			var sql = string.Format("SELECT ID, {0} FROM {1} {2} {5} AND userID = {6} LIMIT {3} OFFSET {4}",
					string.Join(", ", _dataMapper.Attributes),//0
					_dataMapper.TableName,//1
					sqlWhere,//2
					limit,//3
					offset,//4
					parsedWords.Length == 0 ? "" : string.Join(" ", parsedWords),//5
					UserID//6
			);
			return _dataMapper.Query(new MySqlCommand(sql));
		}

		private DataMapper<T> MapperSelector()
		{
			DataMapper<T> mapper = null;
			if (DataMapper != null)
			{
				mapper = (DataMapper<T>)DataMapper;
			}
			else if (UpdatableDataMapper != null)
			{
				mapper = (UpdatableDataMapper<T>)UpdatableDataMapper;
			}
			return mapper;

		}
	}
}
