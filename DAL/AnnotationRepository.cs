using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System;

namespace DAL
{
    public class AnnotationRepository
    {
        public IAnnotationMapper<Annotation> AnnotationMapper { get; set; }

        public AnnotationRepository(IAnnotationMapper<Annotation> datamapper)
        { AnnotationMapper = datamapper; }


        public IEnumerable<Annotation> GetAllAnnotation(int limit = 10, int offset = 0)
        {
            //create the SQL statement

            var sql = string.Format(
                    "select id, body, date from annotation limit {0} offset {1}",
                    limit, offset);
            return AnnotationMapper.GetAll(new MySqlCommand(sql));
            // fetch the selected movies
            // foreach (var post in ExecuteQuery(sql))
            //   yield return post;
        }

        public Annotation GetId(int id)
        {
            return AnnotationMapper.GetById(id);
        }

    }
        }
       