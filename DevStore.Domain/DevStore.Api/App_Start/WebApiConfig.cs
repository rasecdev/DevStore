using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DevStore.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            //Configuração para o que o Json seja o formato principal da API.
            
            var formatters = GlobalConfiguration.Configuration.Formatters;

            var jsonFormatter = formatters.JsonFormatter;

            var settings = jsonFormatter.SerializerSettings;

            //Configuráção para preservar a referência da serialização.
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            //Remoção do XML.
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //Configuração do formato dde saída dos dados.
            settings.Formatting = Formatting.Indented;
            //Converter os nomes da propriedades em mínúsculas.
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
