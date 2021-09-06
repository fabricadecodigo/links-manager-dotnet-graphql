using HotChocolate.Types;
using LinkManager.Api.GraphQL.Api;
using LinkManager.BusinessRules;
using LinkManager.Domain.Extensions;
using LinkManager.Helpers.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LinkManager.Api.GraphQL
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
                .AddMongoDbClient(Configuration)
                .AddMongoDbContext(Configuration);

            services
                // esse método só aparece no package
                // AutoMapper.Extensions.Microsoft.DependencyInjection
                .AddAutoMapper(typeof(Startup))
                .AddHttpClient()
                .AddHelpers()
                .AddBusinessRules();

            services
                .AddGraphQLServer()
                .AddAuthorization()
                // ajustando o formatodo tipo Guid para 00000000-0000-0000-0000-000000000000
                // https://chillicream.com/docs/hotchocolate/defining-a-schema/scalars/#net-scalars
                .AddType(new UuidType('D'))
                .AddQueriesAndMutations();
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
