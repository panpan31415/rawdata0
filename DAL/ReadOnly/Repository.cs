using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReadOnly
{
    public class Repository<T> : IRepository<T> where T : class, IIdentityField
    {

        public IDataMapper<T> DataMapper
        {
            get; set;
        }
        public  IEnumerable<T> GetAll(int limit = 10, int offset = 0)
        {
            var sql = string.Format("select {0} from {1} limit {2} offset {3}", string.Join(", ", DataMapper.Attributes),
               DataMapper.TableName, limit, offset);
             return DataMapper.Query(new MySqlCommand(sql));
        }

        public T GetById(int id)
        {
            return DataMapper.Find(id);
        }


    }
}
