using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System;

namespace DAL
{
    public class AnnotationRepository
    {
        public IEnumerable<Annotation> GetAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select postID, body, date from annotation limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var anno in ExecuteQuery(sql))
                yield return anno;
        }
        private static IEnumerable<Annotation> ExecuteQuery(string sql)
        {
            // create the connection
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                // open the connection to the database
                connection.Open();
                // create the command
                var cmd = new MySqlCommand(sql, connection);
                // get the reader (cursor)
                using (var rdr = cmd.ExecuteReader())
                {
                    // as long as we have rows we can read
                    while (rdr.HasRows && rdr.Read())
                    {
                        int PostId;
                        string Body;
                        DateTime Date;

                        if (!rdr.IsDBNull(0)) { PostId = rdr.GetInt32(0); }
                        else { PostId = 0; }

                        if (!rdr.IsDBNull(1)) { Body = rdr.GetString(1); }
                        else { Body = "unknown"; }

                        if (!rdr.IsDBNull(2)) { Date = rdr.GetDateTime(2); }
                        else { Date = DateTime.Now; }


                        //return a movie object and yield
                        yield return new Annotation
                        {
                            PostId = PostId,
                            Body = Body,
                            Date = Date,

                        };
                    }
                }
            }
        }
        public Annotation GetById(int PostId)
        {
            var sql = string.Format("select postID, body, date from annotation where postId={0} ", PostId);
            return ExecuteQuery(sql).FirstOrDefault();
        }

        public int GetNewId()
        {
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("select max(postID) from annotation", connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows && rdr.Read())
                    {
                        return rdr.GetInt32(0) + 1;
                    }
                }
            }
            return 1;
        }

        public void Add(Annotation annotation)
        {
            annotation.PostId = GetNewId();
            using (var connection = new MySqlConnection(
             ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "insert into annotation(body) values(@body)", connection);
                //cmd.Parameters.AddWithValue("@postID", annotation.PostId);
                cmd.Parameters.AddWithValue("@body", annotation.Body);
                //cmd.Parameters.AddWithValue("@date", annotation.Date);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Annotation annotation)
        {
            using (var connection = new MySqlConnection(
                 ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "update annotation set body=@body where postID=@postID", connection);
                cmd.Parameters.AddWithValue("@postID", annotation.PostId);
                cmd.Parameters.AddWithValue("@body", annotation.Body);
                cmd.ExecuteNonQuery();
            }
        }
    }
}