using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
	public class VoteRepository : Repository<Vote>
	{
		public VoteRepository(IUpdatableDataMapper<Vote> dataMapper) : base(dataMapper) { }
		public void Insert(Vote vote)
		{
			UpdatableDataMapper.Insert(vote);
		}
	}
}
