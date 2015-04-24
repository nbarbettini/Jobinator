using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Jobinator.Core.WebApiConfig
{
    public static class CommonWebApiConfig
    {
        public static void Setup(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure JSON response formatting
            var jsonFormatter = new JsonMediaTypeFormatter();

            // camelCase for the Angular world
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            jsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
            jsonFormatter.SerializerSettings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;

            // JSON array vulnerability protection (temporarily disabled)
            //jsonFormatter.SerializerSettings.Converters.Add(new AngularArrayConverter());

            // remove all other content negotiators so we return only JSON
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            config.Filters.Add(new ServerRetryHeaderFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}
