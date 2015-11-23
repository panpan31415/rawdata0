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
	public class UsersController : BaseApiController
    {
		static UserMapper dataMapper = new UserMapper(ConfigurationManager.ConnectionStrings["remote"].ConnectionString);
		UserRepository _userRepository = new UserRepository(dataMapper);
		public IEnumerable<UserModel> Get()
		{
			var helper = new UrlHelper(Request);
			return _userRepository.GetAll()
				.Select(user => ModelFactory.Create(user));
		}



		public HttpResponseMessage GetById(int id)
		{
			var helper = new UrlHelper(Request);
			var annotation = _userRepository.GetById(id);
			if (annotation == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);

			}
			return Request.CreateResponse(
				HttpStatusCode.OK
				, ModelFactory.Create(annotation));

		}


		//UserRepo _userRepo = new UserRepo();

		//public IEnumerable<UserModel> Get()
		//{
		//	var helper = new UrlHelper(Request);
		//	return _userRepo.GetAll().Select(user => ModelFactory.Create(user));//HERESS
		//}
		//public HttpResponseMessage Get(int id)
		//{
		//	var helper = new UrlHelper(Request);
		//	var user = _userRepo.GetById(id);
		//	if(user == null)
		//	{
		//		return Request.CreateResponse(HttpStatusCode.NotFound);
		//	}
		//	return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(user));
		//}

		//public HttpResponseMessage Post([FromBody] UserModel model)
		//{
		//	var helper = new UrlHelper(Request);
		//	var user = ModelFactory.Parse(model);
		//	_userRepo.Add(user);
		//	return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(user));
		//}

		//public HttpResponseMessage Put(int id, [FromBody] UserModel model)
		//{
		//	var helper = new UrlHelper(Request);
		//	var user = ModelFactory.Parse(model);
		//	user.Id = id;
		//	_userRepo.Update(user);
		//	return Request.CreateResponse(HttpStatusCode.OK);
		//}
	}
}