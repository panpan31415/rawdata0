using DAL;
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
	public class QuestionsController : BaseApiController
	{
		static QuestionMapper dataMapper = new QuestionMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		QuestionRepository _questionRepository = new QuestionRepository(dataMapper);

		public IEnumerable<QuestionModel> Get(int limit, int page) {
			if (limit > 100) limit = 10;
			int offset = page * limit;
			var helper = new UrlHelper(Request);
			return _questionRepository.GetAllQuestions(limit, offset).Select(question => ModelFactory.Create(question));
		}

		[AcceptVerbs("GET", "HEAD")]
		public IEnumerable<QuestionModel> GetByKey(string keywords)
		{
			var helper = new UrlHelper(Request);
			return _questionRepository.GetAllQuestionsByKey(keywords).Select(question => ModelFactory.Create(question));
		}

		public HttpResponseMessage GetById(int id) {
			var helper = new UrlHelper(Request);
			var question = _questionRepository.GetById(id);
			if(question ==null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(question));
		}
	}
}