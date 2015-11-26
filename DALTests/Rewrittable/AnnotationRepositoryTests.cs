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
            AnnotationMapper dataMapper = new AnnotationMapper(connectionString);
            _annoRepository = new AnnotationRepository(dataMapper);
		}
		/// <summary>
		/// given id = 6;
		/// should have userid = 1 and postid = 7664;
		/// </summary>
		[TestMethod()]
		public void getByIdTest()
		{
			initiaizeTest();
            var annotation = _annoRepository.GetById(6);
			Assert.AreEqual(1, annotation.UserId);
			Assert.AreEqual(7664, annotation.PostId);
		}
		/// <summary>
		/// given userid = 1 and postid = 7664
		///  should have id = 6
		/// </summary>
		[TestMethod()]
		public void getByPostAndUserTest()
		{
			initiaizeTest();
			var annotation = _annoRepository.GetByPostAndUser(7664,1);
			var actual = annotation.Id;
			Assert.IsTrue(6== actual);			
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
			_annoRepository.Insert(expected);
			initiaizeTest();
			Annotation actual = _annoRepository.GetByPostAndUser(postid,userid);
			Assert.IsTrue(expected.PostId == actual.PostId);
			Assert.IsTrue(expected.UserId == actual.UserId);
		}

		//[TestMethod()]
		//public void UpdationTest()
		//{
		//	Assert.Fail();
		//}

		//[TestMethod()]
		//public void GetByPostAndUserTest()
		//{
		//	Assert.Fail();
		//}
	}
}