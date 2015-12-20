namespace AspNetConfigurationVS
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.Configuration;

    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddXmlFile("appsettings.xml")
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            var setting1 = _configuration["setting1"];
            var setting2 = _configuration["setting2"];
            var setting3 = _configuration["setting3"];
            var commandTimeout = _configuration["data:commandTimeout"];
            var defaultConnection = _configuration["data:connectionStrings:default"];

            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    $"<div>Setting 1 = {setting1}</div>" +
                    $"<div>Setting 2 = {setting2}</div>" +
                    $"<div>Setting 3 = {setting3}</div>" +
                    $"<div>Command Timeout = {commandTimeout}</div>" +
                    $"<div>Default Connection = {defaultConnection}</div>");
            });
        }
    }
}