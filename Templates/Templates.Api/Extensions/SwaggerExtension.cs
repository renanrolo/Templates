using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Templates.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IApplicationBuilder UseSwagger(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            var useSwagger = configuration.GetValue("UseSwagger", false);
            var projectName = configuration.GetValue("ProjectName", "API");

            return useSwagger
                ? app.UseSwagger().UseSwaggerUI(SwaggerUIConfig(projectName))
                : app;
        }

        private static Action<SwaggerUIOptions> SwaggerUIConfig(string projectName) =>
            c => c.SwaggerEndpoint("/swagger/v1/swagger.json", projectName);

        private static OpenApiInfo SwaggerInfo(string projectName) => new OpenApiInfo
        {
            Title = projectName,
            Version = "V1",
            Description = projectName
        };
    }
}
