using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using System.IO;
using SwiftCode.BBS.Common.Helper;
using Swashbuckle.AspNetCore.Filters;

namespace SwiftCode.BBS.API
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
            services.AddControllers();
            services.AddSingleton(new Appsettings(Configuration));
            services.AddRazorPages();
            
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition ("oath2",new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization, the data will be transferred in the request header, directly in the lower box entering Bearer{token} separated by a space between the two ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SwiftCode.BBS.API",
                    Version = "v0.1.0",
                    Description = "Framework Description",
                    Contact = new OpenApiContact
                    {
                        Name = "Bianyu Wang",
                        Email = "Bwang@totallogistics.com"

                    }
                }
                ) ;
               

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SwiftCode.BBS.API.xml");
                
                c.IncludeXmlComments(xmlPath, true);


                var xmlModelPath = Path.Combine(basePath, "SwiftCode.BBS.Model.xml");

                c.IncludeXmlComments(xmlModelPath);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
               //     c.RoutePrefix = "";
                }

                );


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
