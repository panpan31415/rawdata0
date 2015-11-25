using DAL;
using portfolio2gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace portfolio2gr4.Controllers
{
	public class PostsController : BaseApiController
	{
		PostRepository _postRepository = new PostRepository();
		public IEnumerable<PostModel> Get()
		{
			var helper = new UrlHelper(Request);
			return _postRepository.GetAll()
				.Select(post => ModelFactory.Create(post));
		}
		//public HttpResponseMessage Get(int id)
		//{
		//    var helper = new UrlHelper(Request);
		//    var post = _postRepository.GetById(id);
		//    if (post == null)
		//    {
		//        return Request.CreateResponse(HttpStatusCode.NotFound);

		//    }
		//    return Request.CreateResponse(
		//        HttpStatusCode.OK
		//        , ModelFactory.Create(post));

		//}

		public HttpResponseMessage Post([FromBody] PostModel model)
		{
			var helper = new UrlHelper(Request);
			var post = ModelFactory.Parse(model);
			_postRepository.Add(post);
			return Request.CreateResponse(
				HttpStatusCode.Created
				, ModelFactory.Create(post));
		}
	}
}
