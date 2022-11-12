using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Social.Api.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApiVersioning(config =>  //report versioning
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader(); //report versioning on header
            });

            builder.Services.AddVersionedApiExplorer(config =>  //report versioning for swagger route to view
            {
                config.GroupNameFormat = "'v'VVV";
                config.SubstituteApiVersionInUrl = true;
            });


            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
