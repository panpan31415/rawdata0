using System.Collections.Generic;
using DAL;
using portfolio2gr4.Models;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Configuration;
using DAL.ReadOnly;

namespace portfolio2gr4.Controllers
{
	public class CommentController : BaseApiController
	{

		private CommentRepository _commentRepository;
		private IDataMapper<Comment> _dataMapper;

		// url = api/comments/{id}
		public CommentController() : base()
		{
			_dataMapper = new CommentMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
			_commentRepository = new CommentRepository(_dataMapper);
		}
		[HttpGet]
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
		}
	}
}
