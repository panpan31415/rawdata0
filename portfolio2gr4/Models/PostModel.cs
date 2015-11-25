using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio2gr4.Models
{
	public class PostModel
	{
		public int OwnerId { get; set; }
		public string Url { get; set; }
		public DateTime CreationDate { get; set; }
		public int Score { get; set; }
		public string Body { get; set; }
		public string Title { get; set; }
	}
}