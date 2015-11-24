using Microsoft.VisualStudio.TestTools.UnitTesting;
using portfolio2gr4.Controllers;
using portfolio2gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio2gr4.Controllers.Tests
{
    [TestClass()]
    public class CommentControllerTests
    {
        CommentController commentController = new CommentController();
        [TestMethod()]
        public void GetbyIdTest()
        {
            CommentModel commentModel = commentController.GetbyId(92449);
            Assert.Fail();
        }

        [TestMethod()]
        public void CommentControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetbyIdTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByPostIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByUserIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByKeyWordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByCreationDateTest()
        {
            Assert.Fail();
        }
    }
}