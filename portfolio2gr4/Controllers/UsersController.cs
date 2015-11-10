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
	public class UsersController : BaseApiController
    {
		UserRepo _userRepo = new UserRepo();

		public IEnumerable<UserModel> Get()
		{
			var helper = new UrlHelper(Request);
			return _userRepo.GetAll().Select(user => ModelFactory.Create(user));//HERESS
		}
		public HttpResponseMessage Get(int id)
		{
			var helper = new UrlHelper(Request);
			var user = _userRepo.GetById(id);
			if(user == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(user)	);
		}

		public HttpResponseMessage Post([FromBody] UserModel model)
		{
			var helper = new UrlHelper(Request);
			var user = ModelFactory.Parse(model);
			_userRepo.Add(user);
			return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(user));
		}

		public HttpResponseMessage Put(int id, [FromBody] UserModel model)
		{
			var helper = new UrlHelper(Request);
			var user = ModelFactory.Parse(model);
			user.Id = id;
			_userRepo.Update(user);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
	}
}