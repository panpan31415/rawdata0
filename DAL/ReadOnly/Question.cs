using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Question:Post
	{
		public int AcceptedAnswerId { get; set; }
		public Answer[] Answers { get; set; }
	}
}
