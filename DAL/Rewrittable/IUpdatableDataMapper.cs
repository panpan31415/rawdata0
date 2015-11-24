using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Rewrittable
{
    public interface IUpdatableDataMapper<T> : IDataMapper<T> where T : class, IIdentityField
    {
        void Insert(T entity);
        void Update(T entity);
    }
}
