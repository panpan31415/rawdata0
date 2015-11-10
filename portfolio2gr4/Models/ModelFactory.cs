using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using DAL;
using portfolio2gr4.Models;

namespace WebService.Models
{
	public class ModelFactory
	{

		private UrlHelper _urlHelper;

		// create the url helper with the injected request
		public ModelFactory(HttpRequestMessage request)
		{
			_urlHelper = new UrlHelper(request);
		}

		public UserModel Create(User user)
		{
			return new UserModel
			{
				Url = _urlHelper.Link("UserApi", new { Id = user.Id }), //HERE
				Name = user.Name,
				About = user.About
			};
		}

		public User Parse(UserModel model)
		{
			return new User
			{
				Name = model.Name,
				About = model.About
			};
		}

	}
}