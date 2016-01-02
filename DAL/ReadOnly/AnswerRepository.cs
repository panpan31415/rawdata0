using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly
{
	public class AnswerRepository : Repository<Answer>
	{
		private string connectionString;
		public AnswerRepository(String connectionString) : base(new AnswerMapper(connectionString)) {
			this.connectionString = connectionString;
        }

		public IEnumerable<Comment> getCommentsByPostID(int PostID, int limit = 10, int offset = 0)
		{
			CommentMapper commentMapper = new CommentMapper(connectionString);
			var sql = string.Format("SELECT ID, {0} FROM {1} {2} LIMIT {3} OFFSET {4}",
					string.Join(", ", commentMapper.Attributes),//0
					commentMapper.TableName,//1
					"where postID = " + PostID,//2
					limit,//3
					offset//4
			);
			return commentMapper.Query(new MySqlCommand(sql));
		}
	}
}
