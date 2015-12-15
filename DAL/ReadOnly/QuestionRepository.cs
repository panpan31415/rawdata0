using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
	public class QuestionRepository : Repository<Question>
	{
		public QuestionRepository(IDataMapper<Question> dataMapper) : base(dataMapper) { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="searchText"></param>
		/// <param name="columns"></param>
		/// <param name="limit"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public IEnumerable<Question> GetByFullTextSearch(string searchText, string columns, int limit = 10, int offset = 0)
		{
			var condition = "where match (" + columns + ") " + "against( '" + searchText + "') ORDER BY Title ASC ";
			var sql = string.Format("SELECT ID, {0}{1} FROM {2} {3} limit {4} offset {5} ",
				string.Join(", ", DataMapper.Attributes),
				",match (" + columns + ")" + "against ('" + searchText + "') AS title_relevance",
				DataMapper.TableName,
				condition,
				limit,
				offset
				);
			return DataMapper.Query(new MySqlCommand(sql));
		}
	}
}
