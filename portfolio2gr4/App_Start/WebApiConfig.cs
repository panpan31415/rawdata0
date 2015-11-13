using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace portfolio2gr4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			config.Routes.MapHttpRoute(
				name:"UserApi",
				routeTemplate:"api/{controller}/{id}",
				defaults: new { controller = "Comment", id = RouteParameter.Optional }
				);

			config.Routes.MapHttpRoute(
				name: "PostApi",
				routeTemplate: "api/posts/{id}",
				defaults: new { controller = "Posts", id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "AnnotationApi",
				routeTemplate: "api/annotations/{id}",
				defaults: new { controller = "Annotations", id = RouteParameter.Optional }

				);

			config.Routes.MapHttpRoute(
				name: "CommentApi",
				routeTemplate: "api/comments/{id}",
				defaults: new { controller = "Comment", id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
			   name: "HistoryApi",
			   routeTemplate: "api/historys/{id}",
			   defaults: new { controller = "Historys", id = RouteParameter.Optional }
		   );
		}
    }
}
