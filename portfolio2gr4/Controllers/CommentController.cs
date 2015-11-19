using System.Collections.Generic;
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


        CommentRepository _commentRepository = new CommentRepository();

        public IEnumerable<CommentModel> Get()
        {
            var helper = new UrlHelper(Request);
            return _commentRepository.get().Select(comment => ModelFactory.Create(comment));//HERESS
        }
        public HttpResponseMessage Get(int id)
        {

            var comment = _commentRepository.getById(id);
            if (comment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        //public HttpResponseMessage Post([FromBody] CommentModel model)
        //{
        //    var helper = new UrlHelper(Request);
        //    _commentRepository.addComment(ModelFactory.Parse(model));
        //    return Request.CreateResponse(HttpStatusCode.Created,"a new comment has been added into database");
        //}
        //public HttpResponseMessage Put([FromBody] CommentModel model)
        //{
        //    var helper = new UrlHelper(Request);
        //   // _commentRepo.addComment(ModelFactory.Parse(model));
        //    return Request.CreateResponse(HttpStatusCode.Created, "a new comment has been added into database");
        //}

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