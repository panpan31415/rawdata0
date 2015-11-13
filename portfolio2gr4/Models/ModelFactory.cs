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
				WebsiteUrl = user.WebsiteUrl,
				Reputation = user.Reputation,
				CreationDate = user.CreationDate,
				Age = user.Age,
				UpVotes = user.UpVotes,
				DownVotes = user.DownVotes,
				LocationId = user.LocationId

			};
		}

		public User Parse(UserModel model)
		{
			return new User
			{
				Name = model.Name,
				WebsiteUrl = model.WebsiteUrl,
				Reputation = model.Reputation,
				CreationDate = model.CreationDate,
				Age = model.Age,
				UpVotes = model.UpVotes,
				DownVotes = model.DownVotes,
				LocationId = model.LocationId
			};
		}

        public CommentModel Create(Comment comment)
        {
            return new CommentModel
            {
                postId = comment.postId,
                creationDate = comment.creationDate,
                text = comment.text,
                userid = comment.userid
            };
        }

        public Comment Parse(CommentModel model)
        {
            return new Comment
            {
                userid = model.userid,
                creationDate = model.creationDate,
                postId = model.postId,
                text = model.text
            };
        }
    }
}