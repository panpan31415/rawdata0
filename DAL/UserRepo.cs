using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserRepo
	{
		public IEnumerable<User> GetAll(int limit = 10, int offset = 0)
		{
			var sql = string.Format("select id, displayName, websiteUrl, reputation, creationDate, age, upVotes, downVotes, locationId from user limit {0} offset {1}", limit, offset);
			foreach (var user in ExecuteQuery(sql))
				yield return user;
		}

		private static IEnumerable<User> ExecuteQuery (string sql)
		{
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand(sql, connection);
				using (var rdr = cmd.ExecuteReader())
				{
					while (rdr.HasRows && rdr.Read())
					{
						int uid, u_rep, u_age, u_up, u_down, u_loc;
						string u_name, u_websiteUrl;
						DateTime u_creationDate;

						if (!rdr.IsDBNull(0)) {  uid = rdr.GetInt32(0); } 
						else { uid = 0; }
						if (!rdr.IsDBNull(1)) { u_name = rdr.GetString(1); }
						else { u_name = "unknown"; }
						if (!rdr.IsDBNull(2)) { u_websiteUrl = rdr.GetString(2); }
						else { u_websiteUrl = "unknown"; }
						if (!rdr.IsDBNull(3)) { u_rep = rdr.GetInt32(3); }
						else { u_rep = 0; }
						if (!rdr.IsDBNull(4)) { u_creationDate = rdr.GetDateTime(4); }
						else { u_creationDate = DateTime.Now; }
						if (!rdr.IsDBNull(5)) { u_age= rdr.GetInt32(5); }
						else { u_age = 0; }
						if (!rdr.IsDBNull(6)) { u_up = rdr.GetInt32(6); }
						else { u_up = 0; }
						if (!rdr.IsDBNull(7)) { u_down = rdr.GetInt32(7); }
						else { u_down = 0; }
						if (!rdr.IsDBNull(8)) { u_loc = rdr.GetInt32(8); }
						else { u_loc = 0; }


						yield return new User
						{
							Id =uid,
							Name = u_name,
							WebsiteUrl = u_websiteUrl,
							Reputation = u_rep,
							CreationDate = u_creationDate,
							Age = u_age,
							UpVotes = u_up,
							DownVotes = u_down,
							LocationId = u_loc
						};
					}
				}
			}
		}

		public User GetById(int id)
		{
			var sql = string.Format("select id, displayName, websiteUrl, reputation, creationDate, age, upVotes, downVotes, locationId from user where id = {0}", id);
			return ExecuteQuery(sql).FirstOrDefault();
		}

		public int GetNewId()
		{
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("select max(Id) from user", connection);
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

		public void Add(User user)
		{
			user.Id = GetNewId();
			user.CreationDate = DateTime.Now;
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("insert into user(Id, DisplayName, websiteUrl, reputation, creationDate, age, locationId, upVotes, downVotes) values (@Id, @DisplayName, @WebsiteUrl, 0, @CreationDate, @Age, @LocationId, 0, 0)", connection);
				cmd.Parameters.AddWithValue("@Id", user.Id);
				cmd.Parameters.AddWithValue("DisplayName", user.Name );
				cmd.Parameters.AddWithValue("@WebsiteUrl", user.WebsiteUrl);
				cmd.Parameters.AddWithValue("@CreationDate", user.CreationDate);
				cmd.Parameters.AddWithValue("@Age", user.Age);
				cmd.Parameters.AddWithValue("@LocationId", user.LocationId);
				cmd.ExecuteNonQuery();
			}
		}

		public void Update(User user)
		{
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("update user set DisplayName = @DisplayName, websiteUrl = @WebsiteUrl where Id = @Id )", connection);
				cmd.Parameters.AddWithValue("@Id", user.Id);
				cmd.Parameters.AddWithValue("DisplayName", user.Name);
				cmd.Parameters.AddWithValue("@WebsiteUrl", user.WebsiteUrl);
				cmd.ExecuteNonQuery();
			}
		}

	}
}
