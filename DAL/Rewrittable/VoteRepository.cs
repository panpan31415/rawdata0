using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
	public class VoteRepository : Repository<Vote>
	{
		public VoteRepository(string connectionString) : base(new VoteMapper(connectionString)) { }
		public IEnumerable<Vote> GetByPost(int postid, int limit = 10, int offset = 0)
		{
			var sql = string.Format("SELECT ID, {0} FROM {1} WHERE postId={4} LIMIT {2} OFFSET {3} ",
			string.Join(", ", _dataMapper.Attributes),
			_dataMapper.TableName,
			limit,
			offset,
			postid);
			return _dataMapper.Query(new MySqlCommand(sql));
		}
		public void Insert(Vote vote)
		{
			UpdatableDataMapper.Insert(vote);
		}
	}
}
