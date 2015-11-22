using DAL.ReadOnly;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class CommentRepository : abstractRepository<Comment>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public override IEnumerable<Comment> getAll()
        {
            string sql = string.Format("select * from comment");
            return executeQuery(sql);
        }

        public override Comment getById(int id)
        {
            string sql = string.Format("select * from comment where id = {0}", id);
            return executeQuery(sql).First();
        }

        public IEnumerable<Comment> getByPostId(int postId)
        {
            string sql = string.Format("select * from comment where postId = {0}", postId);
            return executeQuery(sql);
        }

        public IEnumerable<Comment> getBycreationDate(DateTime creationDate)
        {
            string sql = string.Format("select * from comment where creationDate = {0:yyyy-mm-dd hh-mm-ss}",
                   creationDate);
            return executeQuery(sql);
        }

        public IEnumerable<Comment> getByUserId(int userId)
        {
            string sql = string.Format("select * from comment where userid = {0}", userId);
            return executeQuery(sql);
        }
        public IEnumerable<Comment> getByKeyWord(string keyword)
        {
            string sql = string.Format("select * from comment where text like %{0}%", keyword);
            return executeQuery(sql);
        }

        private IEnumerable<Comment> executeQuery(string sql)
        {
            sql += " limit " + Limit + " offset " + Offset+ " ;";
            using (MySqlDataReader rdr = dataReader(sql))
            {
                while (rdr.HasRows && rdr.Read())
                {
                    int id = 0;
                    int postId = 0;
                    string text = "no text";
                    DateTime creationDate = DateTime.Now;
                    int userid = 0;
                    //check nulls of database values
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
                        Id = id,
                        PostId = postId,
                        Text = text,
                        CreationDate = creationDate,
                        Userid = userid,
                    };
                }
            }
        }

    }

}
