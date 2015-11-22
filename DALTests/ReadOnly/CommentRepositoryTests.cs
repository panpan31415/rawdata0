using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace DAL.Tests
{
    [TestClass()]
    public class CommentRepositoryTests
    {
       
        [TestMethod()]
        public void getAllTestOnLimit()
        {
            CommentRepository c = new CommentRepository();
            int rightcount = 10;
            c.Limit = 10;
            int b = c.getAll().Count();
            Assert.AreEqual(rightcount,b);       
        }

        [TestMethod()]
        public void getByIdTest()
        {
            CommentRepository c = new CommentRepository();
            Comment comment1 = new Comment
            {
                Id = 92449,
                PostId = 225026,
                Text = "That's interesting. I'm still wondering if that also applies to Ruby.NET or any other interpreters I don't know about. Maybe try to write my own 'simple' .NET binding that'd work on Xbox?",
                CreationDate = DateTime.Parse("2008-10-22 10:14:24"),
                Userid = 23153
            };
            Comment comment2 = c.getById(92449);
            Assert.AreEqual(comment1, comment2);
        }

        //[TestMethod()]
        //public void getByPostIdTest()
        //{
        //    CommentRepository c = new CommentRepository();
        //    Comment comment1 = new Comment
        //    {
        //        Id = 92449,
        //        PostId = 225026,
        //        Text = "That's interesting. I'm still wondering if that also applies to Ruby.NET or any other interpreters I don't know about. Maybe try to write my own 'simple' .NET binding that'd work on Xbox?",
        //        CreationDate = DateTime.Parse("2008-10-22 10:14:24"),
        //        Userid = 23153
        //    };
        //    Comment comment2 = c.getByPostId(225026);
        //    Assert.AreEqual(comment1, comment2);
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getBycreationDateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getByUserIdTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getByKeyWordTest()
        //{
        //    Assert.Fail();
        //}
    }
}