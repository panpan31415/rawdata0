using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
	public abstract class UpdatableDataMapper<T> : DataMapper<T>, IUpdatableDataMapper<T> where T : class, IIdentityField
	{
		public UpdatableDataMapper(string connectionString) : base(connectionString) { }
		public abstract int Insert(T entity);
		public abstract int Update(T entity);
		//public abstract IEnumerable<T> GetByPostAndUser(int postid, int userid);
	}
}
