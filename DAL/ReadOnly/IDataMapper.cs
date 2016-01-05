using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
	public interface IDataMapper<T> where T : class, IIdentityField
	{
		string ConnectionString { get; set; }
		string TableName { get; }
		string[] Attributes { get; }
		//T GetById(int id);
		T Map(MySqlDataReader reader);
		IEnumerable<T> Query(MySqlCommand command);
	}
}
