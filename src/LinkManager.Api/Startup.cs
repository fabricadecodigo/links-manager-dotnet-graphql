using HotChocolate.Types;
using LinkManager.Api.src.Api;
using LinkManager.Api.src.BusinessRules;
using LinkManager.Domain.src.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                // ajustando o formatodo tipo Guid para 00000000-0000-0000-0000-000000000000
                // https://chillicream.com/docs/hotchocolate/defining-a-schema/scalars/#net-scalars
                .AddType(new UuidType('D'))
                .AddQueriesAndMutations();

            services
                .AddMongoDbClient(Configuration)
                .AddMongoDbContext(Configuration);

            services
                .AddBusinessRules();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}
