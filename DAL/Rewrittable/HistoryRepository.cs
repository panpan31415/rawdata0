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
        public HistoryRepository(IUpdatableDataMapper<History> dataMapper) : base(dataMapper) { }

        public void Insert(History history)
        {
            UpdatableDataMapper.Insert(history);
        }

    }
}