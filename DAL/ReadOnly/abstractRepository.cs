using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DAL.ReadOnly
{
    public abstract class abstractRepository<T> : IReadOlnyRepository<T> where T : class, new()
    {
        public abstract IEnumerable<T> get(int limit = 10, int offset = 0);
        public abstract T getById(int id);

        public MySqlDataReader dataReader(string sql)
        {
            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["remote"].ConnectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                return rdr;
            }
        }


    }
}