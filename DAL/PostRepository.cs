using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DAL
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select id, body, score from post limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }
        private static IEnumerable<Post> ExecuteQuery(string sql)
        {
            // create the connection
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
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
                        // return a movie object and yield
                        yield return new Post
                        {
                            Id = rdr.GetInt32(0),
                            Body = rdr.GetString(1),
                            Score = rdr.GetInt32(2),

                        };
                    }
                }
            }
        }
        public int GetNewId()
        {
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("select max(id) from post", connection);
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

        public void Add(Post post)
        {
            post.Id = GetNewId();
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "insert into post(id,body) values(@id, @body)", connection);
                cmd.Parameters.AddWithValue("@id", post.Id);
                cmd.Parameters.AddWithValue("@body", post.Body);
                cmd.ExecuteNonQuery();
            }
        }
    }
}