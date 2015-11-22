using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL.ReadOnly.Tests
{
    class TestAbstractRepository : ReadOnly.abstractRepository<Comment>
    {
        public override IEnumerable<Comment> getAll()
        {
            throw new NotImplementedException();
        }

        public override Comment getById(int id)
        {
            throw new NotImplementedException();
        }

        

    }
    [TestClass()]
    public class abstractRepositoryTests
    {
        [TestMethod()]
        public void dataReaderTest()
        {
            TestAbstractRepository temp = new TestAbstractRepository();
            String sql = "select * from comment limit 10 offset 0";
            MySqlDataReader reader= temp.dataReader(sql);
            Assert.IsFalse(reader.IsClosed);
        }
    }
}