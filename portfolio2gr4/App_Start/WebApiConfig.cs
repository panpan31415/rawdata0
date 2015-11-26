using System.Web.Http;

namespace portfolio2gr4
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{

			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
				name: "UserApi",
				routeTemplate: "api/users/{id}",
				defaults: new { controller = "Users", id = RouteParameter.Optional }
				);

			config.Routes.MapHttpRoute(
				name: "QuestionApi",
				routeTemplate: "api/questions/{id}",
				defaults: new { controller = "Questions", id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "VotesApi",
				routeTemplate: "api/questions/{qid}/votes",
				defaults: new { controller = "Votes" }
			);
			config.Routes.MapHttpRoute(
				name: "AnswerApi",
				routeTemplate: "api/questions/{qid}/answers",
				defaults: new { controller = "Answers" }
			);

			config.Routes.MapHttpRoute(
				name: "QuestionCommentApi",
				routeTemplate: "api/questions/{postid}/comments",
				defaults: new { controller = "Comments", qid = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "AnswersCommentApi",
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
