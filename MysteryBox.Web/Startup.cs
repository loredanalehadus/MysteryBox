using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MysteryBox.WebService.Services;
using MysteryBox.WebService.Services.Common;
using MysteryBox.WebService.Services.ExternalServiceClient;
using MysteryBox.WebService.Services.Mappers;
using NSwag.AspNetCore;

namespace MysteryBox.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwagger();
            services.AddMvc(options => options.Filters.Add(new JsonExceptionFilterAttribute()));

            ConfigureCommonServices(services);
            ConfigureDomainServices(services);
            ConfigureExternalServiceClients(services);
            ConfigureMappers(services);
        }

        private static void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddTransient<IHttpRequestBuilder, HttpRequestBuilder>();
            services.AddSingleton<IXmlService, XmlService>();
            services.TryAddSingleton(typeof(ILoggingService<>), typeof(LoggingService<>));
        }

        private static void ConfigureExternalServiceClients(IServiceCollection services)
        {
            services.AddSingleton<IDomainboxServiceClient, DomainboxServiceClient>();
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddSingleton<IContactService, ContactService>();
        }

        private static void ConfigureMappers(IServiceCollection services)
        {
            services.AddSingleton<IContactRequestMapper, ContactRequestMapper>();
            services.AddSingleton<IContactResponseMapper, ContactResponseMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSwaggerUiWithApiExplorer(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Title = "Mystery box magic";
                    document.Info.Description = "The app that turns SOAP requests into RESTful ones";
                };
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStatusCodePages();
        }
    }
}
