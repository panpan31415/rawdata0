using DAL;
using portfolio2gr4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using WebService.Models;

namespace portfolio2gr4.Controllers
{
	public class QuestionsController : BaseApiController, IPagination
	{	
		public int limit { get; set; }
		public int offset { get; set; }
		public void setLimitOffset(HttpRequestMessage Request)
		{
			if (Request.Headers.Contains("limit"))
			{
				var limit = Request.Headers.GetValues("limit").First();
				this.limit = int.Parse(limit);
			}
			else { limit = 10; }
			if (Request.Headers.Contains("offset"))
			{
				var offset = Request.Headers.GetValues("offset").First();
				this.offset = int.Parse(offset);
			}
			else { offset = 0; }
        }
        private QuestionRepository _questionRepository = new QuestionRepository(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		public HttpResponseMessage Get()
		{
			setLimitOffset(Request);
            var response = Request
				.CreateResponse(
				HttpStatusCode.OK,
				_questionRepository
				.GetAllQuestions(limit, offset)
				.Select(question => ModelFactory.Create(question)));
			response.Headers.Add("ResultNumber", _questionRepository.QueryResultNumber + "");
			return response;
		}

		public IEnumerable<QuestionModel> GetBySearchTitle(string searchText_title)
		{
			return _questionRepository.GetByFullTextSearch(searchText_title, "title", 1000, 0).Select(question => ModelFactory.Create(question));
		}

		public HttpResponseMessage GetBySearch(string searchText)
		{
			setLimitOffset(Request);
			var response = Request
				.CreateResponse(
				HttpStatusCode.OK,
				 _questionRepository.GetByFullTextSearch(searchText, "title,body", 10, 0).Select(question => ModelFactory.Create(question)));
			response.Headers.Add("ResultNumber", _questionRepository.QueryResultNumber + "");
			return response;
		}
		public HttpResponseMessage GetById(int id)
		{
			setLimitOffset(Request);
			var helper = new UrlHelper(Request);
			var question = _questionRepository.GetById(id);
			if (question == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			var response = Request
				.CreateResponse(
				HttpStatusCode.OK,
				ModelFactory.Create(question));
			response.Headers.Add("ResultNumber", _questionRepository.QueryResultNumber + "");
			return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(question));
		}
		public IEnumerable<CommentModel> GetCommentsByQuestionID(int questionID)
		{
			return _questionRepository.getCommentsByPostID(questionID).Select(comment => ModelFactory.Create(comment));
		}
	}
}