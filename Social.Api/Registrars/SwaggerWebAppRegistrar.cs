using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Social.Api.Registrars
{
    public class SwaggerWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => //modified for UI versioning to navigate different version of swagger
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.ApiVersion.ToString());
                }
            });
        }
    }
}
