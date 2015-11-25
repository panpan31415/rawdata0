using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
	public class Answer : Post
	{
		public int ParentId { get; set; }
	}
}
