using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Collections.Generic;


namespace DAL.ReadOnly.Tests
{
    [TestClass()]
    public class CommentRepositoryTests
    {
        private CommentRepository _commentRepository;
        private IDataMapper<Comment> _commentMapper;
        private string _connectionString;

        private void initializeTest()
        {
            _connectionString = "server=localhost;database=stof;uid=root;pwd=panpan_7533";
            _commentMapper = new CommentMapper(_connectionString);
            _commentRepository = new CommentRepository(_commentMapper);
        }
        /// <summary>
        /// for a given id = 14585379
        /// should get a comment with   
        /// postid = 11129343 ,userid=675502
        /// </summary>
        [TestMethod()]
        public void getByIdTest()
        {
            initializeTest();
            var comment = _commentRepository.GetById(14585379);
            Assert.IsTrue(comment.Id == 14585379 && comment.PostId == 11129343 && comment.Userid == 675502);
        }
        /// <summary>
        /// 1. for a specified postid = 225026, should return 3 comments .
        /// 2. check the id for each comment to see if it matches prequeried result with the given post id        
        ///    the ids are : 92449,46049005,46049006
        /// the test result may different depending on your local database sample 
        /// </summary>
        /// 
        [TestMethod()]
        public void getByPostIdTest_ReturnQuantity()
        {
            initializeTest();
            var emume_comments = _commentRepository.getByPostId(225026);
            int actual = 0;
            foreach (var e in emume_comments) { actual++; }
            Assert.AreEqual(3, actual);
        }
        [TestMethod()]
        public void getByPostIdTest_CommentId()
        {
            initializeTest();
            HashSet<int> ids = new HashSet<int>();
            ids.Add(92449);
            ids.Add(46049005);
            ids.Add(46049006);
            HashSet<int> actualIds = new HashSet<int>();
            var emume_comments = _commentRepository.getByPostId(225026);
            bool expected = false;
            foreach (var e in emume_comments) { expected = ids.Contains(e.Id); }
            Assert.IsTrue(expected);
        }
        /// <summary>
        /// the given userid = 23153
        /// expected returned 6 comments
        /// their ids are :   92449,46049005,46049006,451359,451367,451373
        /// 
        /// </summary>
        [TestMethod()]
        public void getByUserIdTest()
        {
            initializeTest();
            HashSet<int> ids = new HashSet<int>();
            ids.Add(92449);
            ids.Add(46049005);
            ids.Add(46049006);
            ids.Add(451359);
            ids.Add(451367);
            ids.Add(451373);
            HashSet<int> actualIds = new HashSet<int>();
            var emume_comments = _commentRepository.getByUserId(23153);
            bool expected = false;
            int expectedQuantity = 0;
            foreach (var e in emume_comments) { expected = ids.Contains(e.Id); expectedQuantity++; }
            Assert.IsTrue(expected && expectedQuantity == 6);
        }
        /// <summary>
        /// give keyword = "english";
        /// should have 4 comments 
        /// ids:5064260,14585379,16793022,30622795
        /// </summary>
        [TestMethod()]
        public void getByKeyWordTest()
        {
            initializeTest();
            HashSet<int> ids = new HashSet<int>();
            ids.Add(5064260);
            ids.Add(14585379);
            ids.Add(16793022);
            ids.Add(30622795);
            HashSet<int> actualIds = new HashSet<int>();
            var emume_comments = _commentRepository.getByKeyWord("english");
            bool expected = false;
            int expectedQuantity = 0;
            foreach (var e in emume_comments) { expected = ids.Contains(e.Id); expectedQuantity++; }
            Assert.IsTrue(expected && expectedQuantity == 4);
        }

    }
}