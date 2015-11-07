using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DAL
{
    public class PostRepository: IPostRepository
    {
        public IEnumerable<Post> GetAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select OwnerUserId, id, creationDate, score, body, title from post  limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var post in ExecuteQuery(sql))
                yield return post;
        }
        private static IEnumerable<Post> ExecuteQuery(string sql)
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
                        int OwnerId, Id, Score;
                        string Body, Title;
                        DateTime CreationDate;

                        if (!rdr.IsDBNull(0)) { OwnerId = rdr.GetInt32(0); }
                        else { OwnerId = 0; }

                        if (!rdr.IsDBNull(1)) { Id = rdr.GetInt32(1); }
                        else { Id = 0; }

                        if (!rdr.IsDBNull(2)) { CreationDate = rdr.GetDateTime(2); }
                        else { CreationDate = DateTime.Now; }

                        if (!rdr.IsDBNull(3)) { Score = rdr.GetInt32(3); }
                        else { Score = 0; }

                        if (!rdr.IsDBNull(4)) { Body = rdr.GetString(4); }
                        else { Body = "unknown"; }

                        if (!rdr.IsDBNull(5)) { Title = rdr.GetString(5); }
                        else { Title = "Unknown"; }

                        // return a movie object and yield
                        yield return new Post
                        {
                            OwnerId = OwnerId,
                            Id = Id,
                            CreationDate = CreationDate,
                            Score = Score,
                            Body = Body,
                            Title = Title,

                        };
                    }
                }
            }
        }

        public Post GetById(int id)
        {
            var sql = string.Format(
                 "select OwnerUserId, id, creationDate, score, body, title from post where id= {0}", id
                );
            return ExecuteQuery(sql).FirstOrDefault();
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
                    "insert into post( id, creationDate, score, body,title) values( @id, @creationDate, @score, @body, @title)", connection);
                //cmd.Parameters.AddWithValue("@OwnerUserId", post.OwnerId);
                cmd.Parameters.AddWithValue("@id", post.Id);
                cmd.Parameters.AddWithValue("@creationDate", post.CreationDate);
                cmd.Parameters.AddWithValue("@score", post.Score);
                cmd.Parameters.AddWithValue("@body", post.Body);
                cmd.Parameters.AddWithValue("@title", post.Title);
                // cmd.Parameters.AddWithValue("@postTypeID", post.PostTypeId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}