using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentRepo
    {
        // only for test purposes 
        public IEnumerable<Comment> getAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format("select id, postId, text, creationDate, userid from comment limit {0} offset {1}", limit, offset);
            foreach (var comment in executeQuery(sql))
                yield return comment;
        }
        /**
            get comment data from database 
            remember to change connection string when you apply this code to
            your project. 
        */
        private  IEnumerable<Comment> executeQuery(string sql)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.HasRows && rdr.Read())
                    {
                        int id = 0;
                        int postId = 0;
                        string text = "no comment";
                        DateTime creationDate = DateTime.Now;
                        int userid = 0;


                        if (!rdr.IsDBNull(0))
                            id = rdr.GetInt32(0);
                        if (!rdr.IsDBNull(1))
                            postId = rdr.GetInt32(1);
                        if (!rdr.IsDBNull(2))
                            text = rdr.GetString(2);
                        if (!rdr.IsDBNull(3))
                            creationDate = rdr.GetDateTime(3);
                        if (!rdr.IsDBNull(4))
                            userid = rdr.GetInt32(4);

                        yield return new Comment
                        {
                            id = id,
                            postId = postId,
                            text = text,
                            creationDate = creationDate,
                            userid = userid,
                        };
                    }
                }
            }
        }

        public Comment getById(int id)
        {
            var sql = string.Format("select id, postId, text, creationDate, userid from comment where id = {0}", id);
            return executeQuery(sql).FirstOrDefault();
        }
        //public IEnumerable<Comment> getCommentById(int c_Id, int limit = 10, int offset = 0)
        //{
        //    var sql = string.Format("select id, postId, text, creationDate, userid from Comment where id = {0} limit {1} offset {2}", c_Id, limit, offset);
        //    foreach (var comment in executeQuery(sql))
        //        yield return comment;
        //}

        public IEnumerable<Comment> getCommentByPostId(int postId, int limit = 10, int offset = 0)
        {
            var sql = string.Format("select id, postId, text, creationDate, userid from Comment where postId = {0} limit {1} offset {2}", postId, limit, offset);
            foreach (var comment in executeQuery(sql))
                yield return comment;
        }

        public IEnumerable<Comment> getCommentByUserId(int userid, int limit = 10, int offset = 0)
        {
            var sql = string.Format("select id, postId, text, creationDate, userid from Comment where userid = {0} limit {1} offset {2}", userid, limit, offset);
            foreach (var comment in executeQuery(sql))
                yield return comment;
        }

        public void addComment(Comment comment)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("insert into comment(id,postId,text,creationDate,userid) values(@id, @postId, @text ,@creationDate, @userid)", conn);
                cmd.Parameters.AddWithValue("@id", comment.id);
                cmd.Parameters.AddWithValue("@postId", comment.postId);
                cmd.Parameters.AddWithValue("@text", comment.text);
                cmd.Parameters.AddWithValue("@creationDate", comment.creationDate);
                cmd.Parameters.AddWithValue("@userid", comment.userid);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void editComment(int id, int postId, string text, DateTime creationDate, int userid)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("update into comment(id,postId,text,creationDate,userid) values(@id, @postId, @text ,@creationDate, @userid)", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@postId", postId);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@creationDate", creationDate);

            }
        }


        //public void Add(User user)
        //{
        //    user.Id = GetNewId();
        //    user.CreationDate = DateTime.Now;
        //    using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
        //    {
        //        connection.Open();
        //        var cmd = new MySqlCommand("insert into user(Id, DisplayName, websiteUrl, reputation, creationDate, age, locationId, upVotes, downVotes) values (@Id, @DisplayName, @WebsiteUrl, 0, @CreationDate, @Age, @LocationId, 0, 0)", connection);
        //        cmd.Parameters.AddWithValue("@Id", user.Id);
        //        cmd.Parameters.AddWithValue("DisplayName", user.Name);
        //        cmd.Parameters.AddWithValue("@WebsiteUrl", user.WebsiteUrl);
        //        cmd.Parameters.AddWithValue("@CreationDate", user.CreationDate);
        //        cmd.Parameters.AddWithValue("@Age", user.Age);
        //        cmd.Parameters.AddWithValue("@LocationId", user.LocationId);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public void Update(User user)
        //{
        //    using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
        //    {
        //        connection.Open();
        //        var cmd = new MySqlCommand("update user set DisplayName = @DisplayName, websiteUrl = @WebsiteUrl where Id = @Id )", connection);
        //        cmd.Parameters.AddWithValue("@Id", user.Id);
        //        cmd.Parameters.AddWithValue("DisplayName", user.Name);
        //        cmd.Parameters.AddWithValue("@WebsiteUrl", user.WebsiteUrl);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

    }

}
