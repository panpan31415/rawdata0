using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
	public class Vote : IIdentityField
	{
		public int Id { get; set; }
		public int VoteType { get; set; }
		public DateTime Date { get; set; }
		public int UserId { get; set; }
		public int PostId { get; set; }
	}
}
