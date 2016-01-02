using DAL.ReadOnly;
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
		private string connectionString;
		public QuestionRepository(String connectionString) : base(new QuestionMapper(connectionString))
		{
			this.connectionString = connectionString;
        }

		public IEnumerable<Question> GetAllQuestionsByKey(string key, int limit = 10, int offset = 0)
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

		public IEnumerable<Comment> getCommentsByPostID(int PostID, int limit = 10, int offset = 0)
		{
			CommentMapper commentMapper = new CommentMapper(connectionString);
			var sql = string.Format("SELECT ID, {0} FROM {1} {2} LIMIT {3} OFFSET {4}",
					string.Join(", ", commentMapper.Attributes),//0
					commentMapper.TableName,//1
					"where postID = "+ PostID,//2
					limit,//3
					offset//4
			);
			return commentMapper.Query(new MySqlCommand(sql));
		}
	}
}
