using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System;

namespace DAL
{
    public class AnnotationRepository : Repository<Annotation>
    {
        public AnnotationRepository(IDataMapper<Annotation> dataMapper) : base(dataMapper) { }
    }
}