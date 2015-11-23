using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class AnnotationMapper: IAnnotationMapper<Annotation>
    {
        public AnnotationMapper()
        { }


        public IEnumerable<Annotation> GetAll(MySqlCommand command)
        {
            using (var connection = new MySqlConnection("server=localhost;database=stackoverflow;uid=root;pwd=princess786"))
            {
                connection.Open();
                command.Connection = connection;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        var annotation = Map(reader);
                        if (annotation == null)
                        {
                            yield break;
                        }
                        yield return annotation;
                    }
                }
            }
        }



        public Annotation GetById(int id)
        {
            var sql = string.Format(
                 "select id, body,date from annotation where id= {0}", id
                );


            using (var connection = new MySqlConnection("server=localhost;database=stackoverflow;uid=root;pwd=princess786"))
            {
                connection.Open();
                //command.Connection = connection;
                using (var cmd = new MySqlCommand(sql))
                {
                    // cmd.Parameters.AddWithValue("@id", id);
                    //  cmd.Parameters.AddWithValue("@body", Body);
                    cmd.Connection = connection;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return Map(reader);
                    }
                    //return ExecuteQuery(sql).FirstOrDefault();
                }
            }
        }
        // public abstract Annotation Map(MySqlDataReader reader);
        public Annotation Map(MySqlDataReader reader)
        {

            while (reader.HasRows && reader.Read())
            {
                int Id;
                string Body;
                DateTime Date;
                if (!reader.IsDBNull(0)) { Id = reader.GetInt32(0); }
                else { Id = 0; }
                if (!reader.IsDBNull(0)) { Body = reader.GetString(1); }
                else { Body = "unknown"; }

                if (!reader.IsDBNull(2)) { Date = reader.GetDateTime(2); }
                else { Date = DateTime.Now; }

                var annotation = new Annotation
                {
                    id = Id,
                    Body = Body,
                    Date= Date
                };

                return annotation;
            }
            return null;
        }
        //public abstract Annotation Insert(Post post);



        
        //public abstract IEnumerable<T> Get(int limit = 10, int offset = 0);


       
    }
}
