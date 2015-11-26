using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly.Tests
{
	[TestClass()]
	public class AnswerRepositoryTests
	{
		private AnswerRepository answerRepository;
        private void initilizeTest()
		{
			String connectionString = "server=wt-220.ruc.dk;database=raw4;uid=raw4;pwd=raw4";
            AnswerMapper answerMaper = new AnswerMapper(connectionString);
			 answerRepository = new AnswerRepository(answerMaper);
		}
		/// <summary>
		/// only test limit number.
		/// </summary>
		[TestMethod()]
		public void getAllTest()
		{
			initilizeTest();
			int limit = 3;
			var answers = answerRepository.GetAll(limit);
			Assert.AreEqual(limit, answers.Count());
        }

		/// <summary>
		/// given id = 271436
		/// 
		/// parentid = 263952;
		/// </summary>
		[TestMethod()]
		public void GetByIdTest()
		{
			initilizeTest();
			int expected = 263952;
			var answer = answerRepository.GetById(271436);
			int actual = answer.ParentId;
            Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// given postid = 263952
		/// expected answerid = 264905,266427,271436,292079
		/// expected quantity = 4
		/// </summary>
		[TestMethod()]
		public void GetByPostTest()
		{
			initilizeTest();
			HashSet<int> expected = new HashSet<int>();
			expected.Add(264905);
			expected.Add(266427);
			expected.Add(271436);
			expected.Add(292079);
			var answers = answerRepository.GetByPost(263952);
			bool actual = false;
			foreach (var a in answers) { actual = expected.Contains(a.Id); }
			Assert.IsTrue(actual && (answers.Count()==4));
		}


	}
}