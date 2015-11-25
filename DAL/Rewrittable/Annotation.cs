using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Rewrittable

{
	public class Annotation : IIdentityField
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int PostId { get; set; }
<<<<<<< HEAD
    }
=======

	}
>>>>>>> 35baf06b092a8c79fccd2a4e856ebe8dcaf33a8a
}