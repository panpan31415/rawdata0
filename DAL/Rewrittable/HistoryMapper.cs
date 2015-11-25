using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
  public  class HistoryMapper : UpdatableDataMapper<History>
    {
        public HistoryMapper(string connectionString) :base (connectionString)
		{
            TableName = "searchhistory";
            Attributes = new string[] { "body", "date", "userid" };
        }

        public override void Insert(History history)
        {
            var sql = string.Format("insert into {0} ({1}) values({2})",
                TableName, AttributeList, DecoratedAttributeList(x => "@" + x));
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@" + Attributes[0], history.Body);
            cmd.Parameters.AddWithValue("@" + Attributes[1], history.Date);
            cmd.Parameters.AddWithValue("@" + Attributes[2], history.UserId);
            ExecuteNonQuery(cmd);
        }
		public override History GetByPostAndUser(int post, int user)
		{
			return new History { };
		}

		public override History Map(MySqlDataReader reader)
        {
			return new History { };
        }

		public override void Update(History history)
		{
			 
		}

	}
}
