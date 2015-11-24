using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DAL
{
    public class HistoryRepository
    {
        public IEnumerable<History> GetAll(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select id, body, searchdate from searchHistory limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var history in ExecuteQuery(sql))
                yield return history;
        }
        private static IEnumerable<History> ExecuteQuery(string sql)
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
                        yield return new History
                        {
                            Id = rdr.GetInt32(0),
                            Text = rdr.GetString(1),
                            SearchDate = rdr.GetDateTime(2),

                        };
                    }
                }
            }
        }
    }
}