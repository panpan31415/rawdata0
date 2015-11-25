using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
  public  class HistoryMapper : UpdatableDataMapper<Annotation>
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

        public override Annotation Map(MySqlDataReader reader)
        {
            if (reader.HasRows && reader.Read())
            {
                int a_id,  a_userId;
                string a_body;
                DateTime a_date;


                if (!reader.IsDBNull(0)) { a_id = reader.GetInt32(0); }
                else { a_id = 0; }
                if (!reader.IsDBNull(1)) { a_body = reader.GetString(1); }
                else { a_body = "unknown"; }
                if (!reader.IsDBNull(2)) { a_date = reader.GetDateTime(2); }
                else { a_date = DateTime.Now; }
                if (!reader.IsDBNull(4)) { a_userId = reader.GetInt32(4); } else { a_userId = 0; }

                var annotation = new Annotation
                {
                    Id = a_id,
                    Body = a_body,
                    Date = a_date,
                    PostId = a_postId,
                    UserId = a_userId

                };
                return annotation;
            }
            return null;
        }
    }
}
