using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly
{
    public interface IRepository<T> where T : class, IIdentityField
    {
        IDataMapper<T> DataMapper { get; }
        T GetById(int id);
        IEnumerable<T> GetAll(int limit,int offset);
    }
}
