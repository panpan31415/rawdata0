using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Rewrittable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable.Tests
{
	[TestClass()]
	public class AnnotationRepositoryTests
	{
		AnnotationRepository _annoRepository;
		private void initiaizeTest()
		{
			string connectionString = "server=wt-220.ruc.dk;database=raw4;uid=raw4;pwd=raw4";
			_annoRepository = new AnnotationRepository(connectionString);
		}
		/// <summary>
		/// given id = 1;
		/// should have userid = 4 and postid = 45325;
		/// </summary>
		[TestMethod()]
		public void getByIdTest()
		{
			initiaizeTest();
			var annotation = _annoRepository.GetById(1);
			Assert.AreEqual(4, annotation.UserId);
			Assert.AreEqual(45325, annotation.PostId);
		}
		/// <summary>
		/// given userid = 4 and postid = 45325
		///  should have id = 1
		/// </summary>
		[TestMethod()]
		public void getByPostAndUserTest()
		{
			initiaizeTest();
			var annotation = _annoRepository.GetByPostAndUser(45325, 4).ToArray()[0];

			var actual = new Annotation { Id=1,PostId= 45325, UserId=4,Body= "something what?", Date= DateTime.Parse("2010-09-01 08:20:00") };
			Assert.AreEqual(annotation.Id, actual.Id);
			Assert.AreEqual(annotation.Body, actual.Body);
			Assert.AreEqual(annotation.PostId, actual.PostId);
			Assert.AreEqual(annotation.UserId, actual.UserId);
			Assert.AreEqual(annotation.Date, actual.Date);

		}

	

		[TestMethod()]
		public void InsertTest()
		{
			initiaizeTest();
			Random rdm = new Random();
			int id = rdm.Next(10000);
			int postid = rdm.Next(10000);
			int userid = rdm.Next(10000);
			Annotation expected = new Annotation
			{
				Id = id,
				UserId = userid,
				PostId = postid,
				Body = "annotation unit test , postid = " + postid + " userid = " + userid,
				Date = DateTime.Now
			};
			int count = _annoRepository.Insert(expected);
			Annotation actual = _annoRepository.GetByPostAndUser(postid, userid).ToArray()[0]; ;
			Assert.IsTrue(expected.PostId == actual.PostId);
			Assert.IsTrue(expected.UserId == actual.UserId);
		}

		/// <summary>
		/// given annotation with userid = 36 , postid = 85553 
		/// </summary>
		[TestMethod()]
		public void UpdationTest()
		{
			initiaizeTest();
			Annotation a = _annoRepository.GetByPostAndUser(85553, 36).ToArray()[0]; ;
			Random rdm = new Random();
            var ramdomNumber = rdm.Next(100000);
			a.Body = "new unit test with a random number = " + ramdomNumber;
			lock (_annoRepository) { int count = _annoRepository.Updation(a); }
            Annotation actual = _annoRepository.GetByPostAndUser(85553, 36).ToArray()[0]; 
			Assert.AreEqual(a.Body, actual.Body);
		}

		//[TestMethod()]
		//public void GetByPostAndUserTest()
		//{
		//	Assert.Fail();
		//}
	}
}