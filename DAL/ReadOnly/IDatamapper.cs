using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly
{
    public interface IDataMapper <T> where T : class, IIdentityField
    {
        string ConnectionString { get; }
        string TableName { get; }
        string[] Attributes { get; }
        T Find(int id);
        T Map(MySqlDataReader reader);
        IEnumerable<T> Query(MySqlCommand command);

    }
}
