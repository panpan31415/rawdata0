﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio2gr4.Models
{
	public class HistoryModel
	{
		public string Url { get; set; }
		public DateTime Date { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
	}
}