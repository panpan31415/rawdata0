using DAL.Rewrittable;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DAL
{
	public class HistoryRepository : Repository<History>
	{
		public HistoryRepository(string connectiomString) : base(new HistoryMapper(connectiomString)) { }

		public int Insert(History history)
		{
			return UpdatableDataMapper.Insert(history);
		}
		public IEnumerable<History> getByUser(int uid)
		{
			return ((HistoryMapper)UpdatableDataMapper).GetByUser(uid);
        }

	}
}