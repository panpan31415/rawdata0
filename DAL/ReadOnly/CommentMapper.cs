using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL.ReadOnly
{
	public class CommentMapper : DataMapper<Comment>
	{
		public CommentMapper(string connectionSting) : base(connectionSting)
		{
<<<<<<< HEAD
			TableName = "Comment";
=======
			TableName = "comment";
>>>>>>> 35baf06b092a8c79fccd2a4e856ebe8dcaf33a8a
			Attributes = new string[] { "postid", "text", "creationDate", "userid" };
		}

		public override Comment Map(MySqlDataReader reader)
		{
<<<<<<< HEAD
			if (reader.Read() && reader.HasRows)
=======
			if (reader.HasRows && reader.Read())
>>>>>>> 35baf06b092a8c79fccd2a4e856ebe8dcaf33a8a
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
<<<<<<< HEAD
			else
			{
				return null;
			}


=======
			else return null;
>>>>>>> 35baf06b092a8c79fccd2a4e856ebe8dcaf33a8a
		}
	}
}
