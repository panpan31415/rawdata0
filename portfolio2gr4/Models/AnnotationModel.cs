using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portfolio2gr4.Models
{
	public class AnnotationModel
	{
		public  int Id  { get; set; }
		public string Date { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int PostId { get; set; }
	}
}