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
		public AnnotationRepository(string connectionString) : base(new AnnotationMapper(connectionString))
		{ }

		public int Insert(Annotation annotation)
		{
			return UpdatableDataMapper.Insert(annotation);
		}

		public int Updation(Annotation annotation)
		{
			return UpdatableDataMapper.Update(annotation);
		}

		public IEnumerable<Annotation>  GetByPostAndUser(int postid, int userid)
		{
			return ((AnnotationMapper)UpdatableDataMapper).GetByPostAndUser(postid, userid);
		}
		public IEnumerable<Annotation> GetByUser( int userid)
		{
			return ((AnnotationMapper)UpdatableDataMapper).GetByUser( userid);
		}



	}
}