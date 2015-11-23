using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL.ReadOnly
{
    public abstract class DataMapper<T> : IDataMapper<T> where T : class, IIdentityField
    {
        /// <summary>
        /// constructor , initialize a connection string for connecting database
        /// </summary>
        /// <param name="connectionString"></param>
        public DataMapper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string DecoratedAttributeList(Func<string, string> selector)
        {
            return string.Join(",", Attributes.Select(selector));
        }
        protected int ExecuteNonQuery(MySqlCommand command)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
        }
        public virtual T Find(int id )
        {
            var sql = string.Format("select id, {0} from {1} wherer id = @id",
             AttributeList, TableName);
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = connection;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return Map(reader);
                    }
                }
            }
        }
        public abstract T Map(MySqlDataReader reader);
        public IEnumerable<T> Query(MySqlCommand command)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                using (var reader = command.ExecuteReader())
                {
                    while (!reader.IsClosed && reader.Read())
                    {
                        T t = Map(reader);
                        if (t == null)
                        {
                            yield break;
                        }
                        yield return t;
                    }
                   
                  
                }
            }
        }
        protected string AttributeList
        {
            get { return string.Join(", ", Attributes); }
        }
        public string[] Attributes { get; set; }
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
    }
}
