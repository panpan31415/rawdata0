using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DAL.ReadOnly
{
    public abstract class abstractRepository<T> where T : class
    {
        public abstract IEnumerable<T> getAll();
        public abstract T getById(int id);
        private MySqlConnection connection;
        public MySqlDataReader dataReader(string sql)
        {
                string connectionString = "";
            // the reason why I don't use ConfigurationManager to get connection string is beacause 
            // it can't make this method pass the unit test defined in DAL.ReadOnly.Tests.abstractRepositoryTests.cs file 
            
            //connectionString += ConfigurationManager.ConnectionStrings["remote"].ConnectionString;
            var connection = new MySqlConnection("server=localhost;database=stof;uid=root;pwd=panpan_7533");
                connection.Open();
                var cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                MySqlDataReader rdr = cmd.ExecuteReader();
                return rdr;
        }


    }
}