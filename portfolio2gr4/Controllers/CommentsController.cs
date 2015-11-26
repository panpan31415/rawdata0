using DAL.Rewrittable;
using System;
using portfolio2gr4.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DAL;
using DAL.ReadOnly;

namespace portfolio2gr4.Controllers
{
	public class CommentsController : BaseApiController
	{
<<<<<<< HEAD:portfolio2gr4/Controllers/CommentsController.cs
		static CommentMapper dataMapper = new CommentMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		CommentRepository _commentRepository = new CommentRepository(dataMapper);

		public HttpResponseMessage GetById(int postid)
		{
			var helper = new UrlHelper(Request);
			var comment = _commentRepository.GetById(postid);
			if (comment == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);

			}
			return Request.CreateResponse(
				HttpStatusCode.OK
				, ModelFactory.Create(comment));

		}

		//panpan code
		/*private CommentRepository _commentRepository;		
=======
		
		private CommentRepository _commentRepository;		
>>>>>>> f2d9665d428ba2efa20d18e7d2b05f9198ad51f1:portfolio2gr4/Controllers/CommentController.cs
		public CommentController() : base()
		{
             IDataMapper<Comment> _dataMapper = new CommentMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
			_commentRepository = new CommentRepository(_dataMapper);
		}
		[HttpGet]
		// url = api/comments/{id}
		public CommentModel GetbyId(int id)
		{
			return ModelFactory.Create(_commentRepository.GetById(id));
		}

		// url = api/comments/
		[HttpGet]
		public IEnumerable<CommentModel> Get()
		{
			return _commentRepository.GetAll().Select(comment => ModelFactory.Create(comment));
		}
		// url = api/comments/postid/{postid}
		[HttpGet]
		public IEnumerable<CommentModel> GetByPostId(int postid)
		{
			return _commentRepository.getByPostId(postid).Select(comment => ModelFactory.Create(comment));
		}
		// url = api/comments/userid/{userid}
		[HttpGet]
		public IEnumerable<CommentModel> GetByUserId(int userid)
		{
			return _commentRepository.getByUserId(userid).Select(comment => ModelFactory.Create(comment));
		}
		// url = api/comments/keyword/{keyword}
		[HttpGet]
		public IEnumerable<CommentModel> GetByKeyWord(string keyword)
		{
			return _commentRepository.getByKeyWord(keyword).Select(comment => ModelFactory.Create(comment));
		}

		// url = api/comments/creationdate/{creationdate}
		// not supported yet !
		[HttpGet]
		public IEnumerable<CommentModel> GetByCreationDate(string creationdate)
		{
			return _commentRepository.getBycreationDate(DateTime.Parse(creationdate)).Select(comment => ModelFactory.Create(comment));
		}*/
	}
}
