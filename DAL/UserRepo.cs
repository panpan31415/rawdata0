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
			var sql = string.Format("select Id, DisplayName, AboutMe from users limit {0} offset {1}", limit, offset);
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
						int uid;
						string u_name;
						string u_about;

						if (!rdr.IsDBNull(0)) {  uid = rdr.GetInt32(0); } 
						else { uid = 0; }
						if (!rdr.IsDBNull(1)) { u_name = rdr.GetString(1); }
						else { u_name = "unknown"; }
						if (!rdr.IsDBNull(2)) { u_about = rdr.GetString(2); }
						else { u_about = "unknown"; }
						//if (String.IsNullOrEmpty(u_name)) { u_name = "unknown"; };
						//if (String.IsNullOrEmpty(u_about)) { u_about = "unknown"; };

						yield return new User
						{
							Id =uid,
							Name = u_name,
							About = u_about
						};
					}
				}
			}
		}

		public User GetById(int id)
		{
			var sql = string.Format("select Id, DisplayName, AboutMe from users where id = {0}", id);
			return ExecuteQuery(sql).FirstOrDefault();
		}

		public int GetNewId()
		{
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("select max(Id) from users", connection);
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
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("insert into users(Id, DisplayName, AboutMe) values (@Id, @DisplayName, @AboutMe)", connection);
				cmd.Parameters.AddWithValue("@Id", user.Id);
				cmd.Parameters.AddWithValue("DisplayName", user.Name );
				cmd.Parameters.AddWithValue("@AboutMe", user.About);
				cmd.ExecuteNonQuery();
			}
		}

		public void Update(User user)
		{
			using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
			{
				connection.Open();
				var cmd = new MySqlCommand("update users set DisplayName = @DisplayName, AboutMe = @AboutMe where Id = @Id )", connection);
				cmd.Parameters.AddWithValue("@Id", user.Id);
				cmd.Parameters.AddWithValue("DisplayName", user.Name);
				cmd.Parameters.AddWithValue("@AboutMe", user.About);
				cmd.ExecuteNonQuery();
			}
		}

	}
}
