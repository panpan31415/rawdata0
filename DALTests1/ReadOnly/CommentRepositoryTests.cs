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
			_connectionString = "server=wt-220.ruc.dk;database=raw4;uid=raw4;pwd=raw4";
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
		/// 1. for a specified postid = 392022, should return 6 comments .
		/// 2. check the id for each comment to see if it matches prequeried result with the given post id        
		///    the ids are : 219181,219191,219201,219253,5094375,40717618
		/// the test result may different depending on your local database sample 
		/// </summary>
		/// 
		[TestMethod()]
		public void getByPostIdTest_ReturnQuantity()
		{
			initializeTest();
			var emume_comments = _commentRepository.getByPostId(392022);
			int actual = 0;
			foreach (var e in emume_comments) { actual++; }
			Assert.AreEqual(6, actual);
		}
		[TestMethod()]
		public void getByPostIdTest_CommentId()
		{
			initializeTest();
			HashSet<int> ids = new HashSet<int>();
			ids.Add(219181);
			ids.Add(219191);
			ids.Add(219201);
			ids.Add(219253);
			ids.Add(5094375);
			ids.Add(40717618);
			HashSet<int> actualIds = new HashSet<int>();
			var emume_comments = _commentRepository.getByPostId(392022);
			bool expected = false;
			foreach (var e in emume_comments) { expected = ids.Contains(e.Id); }
			Assert.IsTrue(expected);
		}
		/// <summary>
		/// the given userid = 23153
		/// expected returned 4 comments
		/// their ids are :   92449,451359,451367,451373
		/// 
		/// </summary>
		[TestMethod()]
		public void getByUserIdTest()
		{
			initializeTest();
			HashSet<int> ids = new HashSet<int>();
			ids.Add(92449);
			ids.Add(451359);
			ids.Add(451367);
			ids.Add(451373);
			HashSet<int> actualIds = new HashSet<int>();
			var emume_comments = _commentRepository.getByUserId(23153);
			bool expected = false;
			int expectedQuantity = 0;
			foreach (var e in emume_comments) { expected = ids.Contains(e.Id); expectedQuantity++; }
			Assert.IsTrue(expected && expectedQuantity == 4);
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