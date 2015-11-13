using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DAL
{
    public class AnnotationRepository
    {
        public IEnumerable<Annotation> GetAllannotation(int limit = 10, int offset = 0)
        {
            // create the SQL statement
            var sql = string.Format(
                    "select userId, date, body from annotation limit {0} offset {1}",
                    limit, offset);
            // fetch the selected movies
            foreach (var anno in ExecuteQuery(sql))
                yield return anno;
        }
        private static IEnumerable<Annotation> ExecuteQuery(string sql)
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
                        yield return new Annotation
                        {
                            UserId = rdr.GetInt32(0),
                            Date = rdr.GetDateTime(1),
                            Body = rdr.GetString(2),
                        };
                    }
                }
            }
        }

        public int GetNewId()
        {
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("select max(userId) from annotation", connection);
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

        public void Add(Annotation annotation)
        {
            annotation.UserId = GetNewId();
            using (var connection = new MySqlConnection(
                ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "insert into annotation(userid,date,body) values(@userid,@date, @body)", connection);
                cmd.Parameters.AddWithValue("@userid", annotation.UserId);
                cmd.Parameters.AddWithValue("@userdate", annotation.Date);
                cmd.Parameters.AddWithValue("@body", annotation.Body);
                cmd.ExecuteNonQuery();
            }
        }
    }
}