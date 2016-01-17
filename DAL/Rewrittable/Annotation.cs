﻿using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Rewrittable

{
	public class Annotation : IIdentityField
	{
		public int Id { get; set; }
		public string Date { get; set; }
		public string Body { get; set; }
		public int PostId { get; set; }
		public int UserId { get; set; }
	}
}