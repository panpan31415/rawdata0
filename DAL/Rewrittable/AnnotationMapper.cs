using MySql.Data.MySqlClient;
using MySql.Data.Types;
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
		public UserMapper userMapper { get; set; }
		public AnnotationMapper(string connectionString):base(connectionString)
		{
			TableName = "annotation";
			Attributes = new string[] { "body", "date", "postid", "userid" };
		}
		public  IEnumerable<Annotation>  GetByPostAndUser(int postid, int userid)
		{
			var sql = string.Format("SELECT ID, {0} from {1} WHERE postID = @postID and userID=@userID", AttributeList, TableName);
			using (var connection = new MySqlConnection(ConnectionString))
			{
				connection.Open();
				using (var cmd = new MySqlCommand(sql))
				{
					cmd.Parameters.AddWithValue("@postID", postid);
					cmd.Parameters.AddWithValue("@userID", userid);
					cmd.Connection = connection;
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return Map(reader);
						}
						yield return null;
					}
				}
			}

		}

		public IEnumerable<Annotation> GetByUser( int userid)
		{
			var sql = string.Format("SELECT ID, {0} from {1} WHERE userID="+ userid , AttributeList, TableName);
			using (var connection = new MySqlConnection(ConnectionString))
			{
				connection.Open();
				using (var cmd = new MySqlCommand(sql))
				{
					
					cmd.Connection = connection;
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return Map(reader);
						}
						
					}
				}
			}

		}

		public override int Insert(Annotation annotation)
		{
			var sql = string.Format("insert into {0} ({1}) values({2})",
				TableName, AttributeList, DecoratedAttributeList(x => "@" + x));
			var cmd = new MySqlCommand(sql);
			 
            cmd.Parameters.AddWithValue("@" + Attributes[0], annotation.Body);
			cmd.Parameters.AddWithValue("@" + Attributes[1], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			cmd.Parameters.AddWithValue("@" + Attributes[2], annotation.PostId);
			cmd.Parameters.AddWithValue("@" + Attributes[3], annotation.UserId);
			return ExecuteNonQuery(cmd);
		}



		public override int Update(Annotation a)
		{
			var sql = "update " + TableName + " set body = '" + a.Body + "' , date ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'  where postID =" + a.PostId + " and userID=" + a.UserId;
			var cmd = new MySqlCommand(sql);
			return ExecuteNonQuery(cmd);
		}
		public override Annotation Map(MySqlDataReader reader)
		{
			if (reader.HasRows)
			{
				int a_id, a_postId, a_userId;
				string a_body;
				string a_date;
				if (!reader.IsDBNull(0)) { a_id = reader.GetInt32(0); }
				else { a_id = 0; }
				if (!reader.IsDBNull(1)) { a_body = reader.GetString(1); }
				else { a_body = "unknown"; }
				if (!reader.IsDBNull(2)) { a_date = reader.GetDateTime(2).ToString("yyyy-MM-dd HH:mm:ss"); }
				else { a_date = DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss"); }
				if (!reader.IsDBNull(3)) { a_postId = reader.GetInt32(3); } else { a_postId = 0; }
				if (!reader.IsDBNull(4)) { a_userId = reader.GetInt32(4); } else { a_userId = 0; }

				var annotation = new Annotation
				{
					Id = a_id,
					Body = a_body,
					Date = a_date,
					PostId = a_postId,
					UserId = a_userId

				};
				return annotation;
			}
			return null;
		}
	}
}
