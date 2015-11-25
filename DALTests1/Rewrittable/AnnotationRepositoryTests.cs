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

        private void initializeTese()
        {
            _annotationMaper = new AnnotationMapper("server=localhost;database=stof;uid=root;pwd=panpan_7533");
            _annotationRepository = new AnnotationRepository(_annotationMaper);
        }

        [TestMethod()]
        public void InsertTestAndGetByIdTest()
        {
            Annotation annotation = new Annotation
            {
                UserId = 741,
                PostId = 225026,
                Date = DateTime.Now,
                Body = "annotation unit test"
            };
            _annotationRepository.Insert(annotation);
            //_annotationRepository.get
        }

        [TestMethod()]
        public void UpdationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByPostAndUserTest()
        {
            Assert.Fail();
        }
    }
}