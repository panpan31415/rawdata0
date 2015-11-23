using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL.ReadOnly
{
    class CommentMapper : DataMapper<Comment>
    {
        public CommentMapper(string connectionSting) : base(connectionSting)
        {
            TableName = "Comment";
            Attributes = new string[] { "id", "postid", "text", "creationDate", "userid" };
        }

        public override Comment Map(MySqlDataReader reader)
        {
            
                int id = 0;
                int postId = 0;
                string text = "no text";
                DateTime creationDate = DateTime.Now;
                int userid = 0;
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    postId = reader.GetInt32(1);
                if (!reader.IsDBNull(2))
                    text = reader.GetString(2);
                if (!reader.IsDBNull(3))
                    creationDate = reader.GetDateTime(3);
                if (!reader.IsDBNull(4))
                    userid = reader.GetInt32(4);
                return new Comment
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
