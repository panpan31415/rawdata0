﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Question:Post
	{
		public string Title { get; set; }
		public int AcceptedAnswerId { get; set; }
		public int answerCount { get; set; }
	}
}
