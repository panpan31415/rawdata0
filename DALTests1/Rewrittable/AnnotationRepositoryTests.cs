using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Data;


namespace DAL.Rewrittable.Tests
{
    [TestClass()]
    public class AnnotationRepositoryTests
    { 
        IUpdatableDataMapper<Annotation> _annotationMaper;
        AnnotationRepository _annotationRepository;

        private void initializeTest()
        {
            _annotationMaper = new AnnotationMapper("server=wt-220.ruc.dk;database=raw4;uid=raw4;pwd=raw4");
            _annotationRepository = new AnnotationRepository(_annotationMaper);
        }

        [TestMethod()]
        public void InsertTestAndGetByPostAndUserTest()
        {
			initializeTest();
			Random rnd = new Random();
            int userid = rnd.Next(10000);
			int postid = rnd.Next(10000);
            Annotation annotation = new Annotation
			{				
				UserId = userid,
				PostId = postid,
				Date = DateTime.Parse("2015-11-25 13:58:23"),
				Body = "annotation unit test with userid = " + userid + " and postid =" + postid,
			};
            _annotationRepository.Insert(annotation);
			Annotation annotation_Actual = _annotationRepository.GetByPostAndUser(postid, userid);
			Assert.AreEqual(annotation.UserId, annotation_Actual.UserId);
        }

        [TestMethod()]
        public void UpdationTest()
        {
			initializeTest();
			Random rnd = new Random();
			int userid = rnd.Next(10000);
			int postid = rnd.Next(10000);
			Annotation annotation = new Annotation
			{
				UserId = userid,
				PostId = postid,
				Date = DateTime.Parse("2016-11-25 13:58:23"),
				Body = "annotation unit test with userid = " + userid + " postid =" + postid,
			};
			_annotationRepository.Insert(annotation);
			annotation.Body = "update";
            _annotationRepository.Updation(annotation);
			Annotation annotation_Actual = _annotationRepository.GetByPostAndUser(postid, userid);
			Assert.AreEqual(annotation.Body, annotation_Actual.Body);
		}
    }
}