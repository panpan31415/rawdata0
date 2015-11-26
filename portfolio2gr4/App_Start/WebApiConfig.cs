using System.Web.Http;

namespace portfolio2gr4
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Web API routes
			//get a singal comment by id , or return all comments
		/*	config.Routes.MapHttpRoute(
				name: "CommentApi",
				routeTemplate: "api/comments/{id}",
				defaults: new
				{
					controller = "Comment",
					id = RouteParameter.Optional
				}
				);*/
			/*config.Routes.MapHttpRoute(
				name: "Comment_userid_Api",
				routeTemplate: "api/comments/userid/{userid}",
				defaults: new
				{
					controller = "Comment"
				}
				);
			config.Routes.MapHttpRoute(
				name: "Comment_postid_Api",
				routeTemplate: "api/comments/postid/{postid}",
				defaults: new
				{
					controller = "Comment"
				}
				);
			config.Routes.MapHttpRoute(
				name: "Comment_creationdate_Api",
				routeTemplate: "api/comments/creationdate/{creationdate}",
				defaults: new
				{
					controller = "Comment"
				}
				);
			config.Routes.MapHttpRoute(
				name: "Comment_keyword_Api",
				routeTemplate: "api/comments/keyword/{keyword}",
				defaults: new
				{
					controller = "Comment"
				}
				);*/

			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "UserApi",
				routeTemplate: "api/users/{id}",
				defaults: new { controller = "Users", id = RouteParameter.Optional }
				);

			//config.Routes.MapHttpRoute(
			//	name: "PostApi",
			//	routeTemplate: "api/posts/{id}",
			//	defaults: new { controller = "Posts", id = RouteParameter.Optional }
			//);
			config.Routes.MapHttpRoute(
				name: "QuestionApi",
				routeTemplate: "api/questions/{id}",
				defaults: new { controller = "Questions", id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "AnswerApi",
				routeTemplate: "api/questions/{qid}/answers",
				defaults: new { controller = "Answers", qid = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "CommentApi",
				routeTemplate: "api/questions/{postid}/comments",
				defaults: new { controller = "Comments", qid = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "CommentApi",
				routeTemplate: "api/answers/{postid}/comments",
				defaults: new { controller = "Comments", qid = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "AnnotationApi",
				routeTemplate: "api/annotations/{id}",
				defaults: new { controller = "Annotations", id = RouteParameter.Optional }
				);

			config.Routes.MapHttpRoute(
				name: "AnnotationApiByUserAndPost",
				routeTemplate: "api/annotations/{postid}/{userid}",
				defaults: new { controller = "Annotations" }
			);

			config.Routes.MapHttpRoute(
			   name: "HistoryApi",
			   routeTemplate: "api/users/{userid}/historys",
			   //routeTemplate: "api/historys/{id}",
			   defaults: new { controller = "Historys", }
			  );
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { attribute = RouteParameter.Optional, id = RouteParameter.Optional }
			);
		}
	}
}
