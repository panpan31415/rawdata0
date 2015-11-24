using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
   public class AnnotationMapper: DataMapper<Annotation>
    {
        public AnnotationMapper(string connectionString) :base (connectionString)
		{
            TableName = "annotation";
            Attributes = new string[] { "id", "body", "date" };
        }


        public override Annotation Map(MySqlDataReader reader)
        {
            if (reader.HasRows && reader.Read())
            {
                int a_id;
                string a_body;
                DateTime a_date;

                if (!reader.IsDBNull(0)) { a_id = reader.GetInt32(0); }
                else { a_id = 0; }
                if (!reader.IsDBNull(1)) { a_body = reader.GetString(1); }
                else { a_body = "unknown"; }
                if (!reader.IsDBNull(2)) { a_date = reader.GetDateTime(2); }
                else { a_date = DateTime.Now; }

                var annotation = new Annotation
                {
                    Id = a_id,
                    Body = a_body,
                    Date= a_date
                    
                };
                return annotation;
            }
            return null;
        }
    }
}
