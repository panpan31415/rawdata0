﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using WebService.Models;
using DAL;
using portfolio2gr4.Models;

namespace portfolio2gr4.Controllers
{
    public class CommentsController : BaseApiController
    {

        
            CommentRepo _commentRepo = new CommentRepo();

            public IEnumerable<CommentModel> Get()
            {
                var helper = new UrlHelper(Request);
                 return _commentRepo.getAll().Select(comment => ModelFactory.Create(comment));//HERESS
            }
            public HttpResponseMessage Get(int id)
            {

                var comment = _commentRepo.getById(id);
                if (comment == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(comment));
            }

            public HttpResponseMessage Post([FromBody] CommentModel model)
            {
                //var helper = new UrlHelper(Request);
                var comment = ModelFactory.Parse(model);
                _commentRepo.addComment(comment);
                return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(comment));
            }

            //public HttpResponseMessage Put(int id, [FromBody] UserModel model)
            //{
            //    var helper = new UrlHelper(Request);
            //    var comment = ModelFactory.Parse(model);
            //    comment.Id = id;
            //    _commentRepo.Update(comment);
            //    return Request.CreateResponse(HttpStatusCode.OK);
            //}
        
    }
}