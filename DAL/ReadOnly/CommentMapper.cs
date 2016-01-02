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

			TableName = "comment";
			Attributes = new string[] { "postId", "text", "creationDate", "Userid" };
		}
		/*public override Comment GetById(int postid)
		{
			var sql = string.Format("SELECT postID, {0} from {1} WHERE postID = @postID", AttributeList, TableName);
			using (var connection = new MySqlConnection(ConnectionString))
			{
				connection.Open();
				using (var cmd = new MySqlCommand(sql))
				{
					cmd.Parameters.AddWithValue("@postID", postid);
					cmd.Connection = connection;
					using (var reader = cmd.ExecuteReader())
					{
						return Map(reader);
					}
				}
			}
		}*/

		public override Comment Map(MySqlDataReader reader)
		{
			if (reader.HasRows)
			{
				int Id;
				int PostId;
				string Text;
				string CreationDate;
				int UserId;
				if (!reader.IsDBNull(0)) { Id = reader.GetInt32(0); }
				else { Id = 0; }
				if (!reader.IsDBNull(1)) { PostId = reader.GetInt32(1); }
				else { PostId = 0; }
				if (!reader.IsDBNull(2)) { Text = reader.GetString(2); }
				else { Text = "Data Lost!"; }
				if (!reader.IsDBNull(3)) { CreationDate = reader.GetString(3); }
				else { CreationDate = "Data Lost!"; }
				if (!reader.IsDBNull(4)) { UserId = reader.GetInt32(4); }
				else { UserId = 0; }

				var comment = new Comment
				{
					Id = Id,
					PostId = PostId,
					Text = Text,
					CreationDate = CreationDate,
					UserId = UserId
				};
				return comment;
			}
			else { return null; }

		}

	}
}
