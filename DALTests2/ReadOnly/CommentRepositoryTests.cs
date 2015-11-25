using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.ReadOnly.Tests
{
    [TestClass()]
    public class CommentRepositoryTests
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["remote"].ConnectionString;
        CommentRepository commentRepository = new CommentRepository(new CommentMapper(connectionString));
        [TestMethod()]
        public void CommentRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getByPostIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getBycreationDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getByUserIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getByKeyWordTest()
        {
            Assert.Fail();
        }
    }
}