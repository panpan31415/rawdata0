using DAL.Rewrittable;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public abstract class Repository<T> : IRepository<T> where T :class, IIdentityField
	{
		public IDataMapper<T> DataMapper { get; set; }
		public Repository(IDataMapper<T> dataMapper)
		{
			DataMapper = dataMapper;
		}
        public IUpdatableDataMapper<T> UpdatableDataMapper { get; set; }
        public Repository(IUpdatableDataMapper<T> updatabledatamapper)
        {
            UpdatableDataMapper = updatabledatamapper;
        }
        public T GetById(long id)
		{
			return DataMapper.GetById(id);
		}
        public void Insert(T annotation)
        {
            UpdatableDataMapper.Insert(annotation);
        }

        public void Updation(T annotation)
        {
            UpdatableDataMapper.Update(annotation);

        }

        public IEnumerable<T> GetAll(int limit= 10, int offset = 0)
		{
			var sql = string.Format("SELECT ID, {0} FROM {1} LIMIT {2} OFFSET {3}",
				string.Join(", ", DataMapper.Attributes),
				DataMapper.TableName,
				limit,
				offset);
			return DataMapper.Query(new MySqlCommand(sql));
		}
	}
}
