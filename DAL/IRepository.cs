using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IRepository<T> where T : class, IIdentityField
	{
		IDataMapper<T> DataMapper { get; }
		T GetById(long id);
		IEnumerable<T> GetAll(int limit=10, int offset = 0);
	}
}
