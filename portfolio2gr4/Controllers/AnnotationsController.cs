using DAL;
using portfolio2gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace portfolio2gr4.Controllers
{
    public class AnnotationsController : BaseApiController
    {
        static AnnotationMapper dataMapper = new AnnotationMapper();
        AnnotationRepository _annoRepository = new AnnotationRepository(dataMapper);
        public IEnumerable<AnnotationModel> Get()
        {
            var helper = new UrlHelper(Request);
            return _annoRepository.GetAllAnnotation()
                .Select(annotation => ModelFactory.Create(annotation));
        }



        public HttpResponseMessage GetId(int id)
        {
            var helper = new UrlHelper(Request);
            var annotation = _annoRepository.GetId(id);
            if (annotation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
            return Request.CreateResponse(
                HttpStatusCode.OK
                , ModelFactory.Create(annotation));

        }
    }
}