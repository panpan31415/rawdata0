using System.Collections.Generic;
using DAL;
using portfolio2gr4.Models;
using System;
using System.Web.Mvc;
using System.Linq;

namespace portfolio2gr4.Controllers
{
    public class CommentController : BaseApiController
    {
        private readonly CommentRepository _commentRepository = new CommentRepository();

        public CommentController() : base()
        {
            _commentRepository.Limit = 10;
            _commentRepository.Offset = 0;
        }
        // url = api/comments/{id}
        [HttpGet]       
        public CommentModel GetbyId(int id)
        {
            return ModelFactory.Create(_commentRepository.getById(id));
        }

        public IEnumerable<CommentModel> Get()

        {
            return _commentRepository.getAll().Select(comment => ModelFactory.Create(comment));
        }

        public IEnumerable<CommentModel> GetByPostId(int postid)
        {
            return _commentRepository.getByPostId(postid).Select(comment => ModelFactory.Create(comment));
        }

        public IEnumerable<CommentModel> GetByUserId(int userid)
        {
            return _commentRepository.getByUserId(userid).Select(comment => ModelFactory.Create(comment));
        }

        public IEnumerable<CommentModel> GetByKeyWord(string keyword)
        {
            return _commentRepository.getByKeyWord(keyword).Select(comment => ModelFactory.Create(comment));
        }
        public IEnumerable<CommentModel> GetByCreationDate(string creationdate)
        {
            return _commentRepository.getBycreationDate(DateTime.Parse(creationdate)).Select(comment => ModelFactory.Create(comment));
        }
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
