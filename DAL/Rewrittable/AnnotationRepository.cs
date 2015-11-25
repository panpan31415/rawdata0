using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System;
using DAL.ReadOnly;

namespace DAL.Rewrittable
{
    public class AnnotationRepository : Repository<Annotation>
    {
        public AnnotationRepository(IUpdatableDataMapper<Annotation> dataMapper) : base(dataMapper) { }
<<<<<<< HEAD
    }
=======

		public void Insert(Annotation annotation)
		{
			UpdatableDataMapper.Insert(annotation);
		}

		public void Updation(Annotation annotation)
		{
			UpdatableDataMapper.Update(annotation);

		}

	}
>>>>>>> 6bebcab7ec5cdc1d1b6b1914e04f8079a64ae4c5
}