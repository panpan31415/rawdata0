using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
   public class AnnotationMapper : UpdatableDataMapper<Annotation>
    {
        public AnnotationMapper(string connectionString) :base (connectionString)
		{
            TableName = "annotation";
            Attributes = new string[] { "body", "date" };
        }
        public override void Insert(Annotation annotation)
        {
            var sql = string.Format("insert into {0}(body, {1}) values(@body, {2})",
                TableName, AttributeList, DecoratedAttributeList(x => "@" + x));
            //  annotation.Id = NextId();
            var cmd = new MySqlCommand(sql);
            // "insert into post( id,  body) values( @id,  @body)");
            //cmd.Parameters.AddWithValue("@OwnerUserId", post.OwnerId);
            cmd.Parameters.AddWithValue("@body", annotation.Body);
            cmd.Parameters.AddWithValue("@" + Attributes[0], annotation.Id);
            cmd.Parameters.AddWithValue("@" + Attributes[1], annotation.Body);
            //cmd.Parameters.AddWithValue("@score", post.Score);
            //cmd.Parameters.AddWithValue("@body", post.Body);
            //cmd.Parameters.AddWithValue("@title", post.Title);
            // cmd.Parameters.AddWithValue("@postTypeID", post.PostTypeId);
            ExecuteNonQuery(cmd);
            // return annotation;
        }

        public override void Update(Annotation annotation)
        {
            var sql = string.Format("update {0} set {1} where postid= @postid",
                TableName, AttributeList, DecoratedAttributeList((x => x + "=@" + x)));
            //  annotation.Id = NextId();
            var cmd = new MySqlCommand(sql);
            // "insert into post( id,  body) values( @id,  @body)");
            //cmd.Parameters.AddWithValue("@OwnerUserId", post.OwnerId);
            cmd.Parameters.AddWithValue("@postid", annotation.Id);
            cmd.Parameters.AddWithValue("@" + Attributes[0], annotation.Body);
            //cmd.Parameters.AddWithValue("@" + Attributes[1], annotation.Body);
            //cmd.Parameters.AddWithValue("@score", post.Score);
            //cmd.Parameters.AddWithValue("@body", post.Body);
            //cmd.Parameters.AddWithValue("@title", post.Title);
            // cmd.Parameters.AddWithValue("@postTypeID", post.PostTypeId);
            ExecuteNonQuery(cmd);

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
