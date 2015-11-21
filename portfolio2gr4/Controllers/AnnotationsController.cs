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
        AnnotationRepository _annoRepository = new AnnotationRepository();
        //ModelFactory _modelFactory = new ModelFactory();
        public IEnumerable<AnnotationModel> Get()
        {
            var helper = new UrlHelper(Request);
            return _annoRepository.GetAll()
                .Select(annotation => ModelFactory.Create(annotation));
        }
        public HttpResponseMessage Get(int id)
        {
            var helper = new UrlHelper(Request);
            var annotation = _annoRepository.GetById(id);
            if (User == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(annotation));
        }


        public HttpResponseMessage Post([FromBody] AnnotationModel model)
        {
            var helper = new UrlHelper(Request);
            var annotation = ModelFactory.Parse(model);
            _annoRepository.Add(annotation);
            return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(annotation));
        }

        public HttpResponseMessage put(int id, [FromBody] AnnotationModel model)
        {
            var helper = new UrlHelper(Request);
            var annotation = ModelFactory.Parse(model);
            annotation.id = id;
            _annoRepository.Update(annotation);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
