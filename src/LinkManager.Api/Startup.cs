using HotChocolate.Types;
using LinkManager.Api.src.Api;
using LinkManager.Api.src.BusinessRules;
using LinkManager.Api.src.Helpers;
using LinkManager.Domain.src.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Salva na API que o usuário está autenticado
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = Configuration.GetValue<string>("JWT:Audience"),
                        ValidIssuer = Configuration.GetValue<string>("JWT:Issuer"),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWT:SecretKey"))),
                        ValidateIssuer = true, // por padrão é true
                        ValidateAudience = true, // por padrão é true
                    };
                });
                
            services
                .AddGraphQLServer()
                .AddAuthorization()
                // ajustando o formatodo tipo Guid para 00000000-0000-0000-0000-000000000000
                // https://chillicream.com/docs/hotchocolate/defining-a-schema/scalars/#net-scalars
                .AddType(new UuidType('D'))
                .AddQueriesAndMutations();

            services
                .AddMongoDbClient(Configuration)
                .AddMongoDbContext(Configuration);

            services
                .AddHelpers()
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
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}
