using System.Web.Http;

namespace RBoggleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PostSolveRoute",
                routeTemplate: "api/{controller}/Solve"
            );
        }
    }
}
