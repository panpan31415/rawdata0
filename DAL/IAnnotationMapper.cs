using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IAnnotationMapper<Annotation>
    {
        Annotation Map(MySqlDataReader reader);
        IEnumerable<Annotation> GetAll(MySqlCommand command);
        Annotation GetById(int id);

    }
}
