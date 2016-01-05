using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using WebService.Models;
using DAL;
using portfolio2gr4.Models;
using System.Configuration;

namespace portfolio2gr4.Controllers
{
	public class UsersController : BaseApiController,IPagination
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
		private UserRepository _userRepository = new UserRepository(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		public HttpResponseMessage Get()
		{
			setLimitOffset(Request);
			var response = Request
				.CreateResponse(
				HttpStatusCode.OK,
				_userRepository
				.GetAll(limit, offset)
				.Select(user => ModelFactory.Create(user)));
			response.Headers.Add("ResultNumber", _userRepository.QueryResultNumber + "");
			return response;
		}
		public HttpResponseMessage GetBySearchName(string searchText_Name)
		{
			setLimitOffset(Request);
			var response = Request
				.CreateResponse(
				HttpStatusCode.OK,
				_userRepository
				.GetByKeyWords(searchText_Name, "displayName", limit, offset).Select(user => ModelFactory.Create(user)));
			response.Headers.Add("ResultNumber", _userRepository.QueryResultNumber + "");
			return response;
			
			//return _userRepository.GetByFullTextSearch(searchText_Name, "displayName", 1000, 0).Select(user => ModelFactory.Create(user));
		}

		public HttpResponseMessage GetById(int id)
		{
			var helper = new UrlHelper(Request);
			var user = _userRepository.GetById(id);
			if (user == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			return Request.CreateResponse(
				HttpStatusCode.OK, ModelFactory.Create(user));
		}

	}
}