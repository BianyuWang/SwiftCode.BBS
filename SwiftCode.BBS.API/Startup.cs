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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Autofac;
using SwiftCode.BBS.Extensions.ServiceExtension;
using SwiftCode.BBS.IServices;


namespace SwiftCode.BBS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string DefaultCorsPolicyName = "Default";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(new Appsettings(Configuration));

         //   services.AddScoped<IArticleService, ArticleServices>();
            services.AddRazorPages();
            
            services.AddSwaggerGen(c =>
            {
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
                });


                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SwiftCode.BBS.API.xml");
                c.IncludeXmlComments(xmlPath, true);


                var xmlModelPath = Path.Combine(basePath, "SwiftCode.BBS.Model.xml");
                c.IncludeXmlComments(xmlModelPath);


                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
              
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Description = "JWT authorization (data will be transferred in the request header) Enter Bear {token} directly in the lower box (note that there is a space between the two)\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

            });
       
            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(o =>
           {
               var audienceConfig = Configuration["Audience:Audience"];
               var symmetricKeyAsBase64 = Configuration["Audience:Secret"];
               var iss = Configuration["Audience:Issuer"];
               var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
               var signingKey = new SymmetricSecurityKey(keyByteArray);
               o.Events = new JwtBearerEvents()
               {
                   OnMessageReceived = context =>
                   {
                       context.Token = context.Request.Query["access_token"];
                       return Task.CompletedTask;
                   }

               };

                   o.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = signingKey,
                   ValidateIssuer = true,
                   ValidIssuer = iss,
                   ValidateAudience = true,
                   ValidAudience = audienceConfig,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero,
                   RequireExpirationTime = true, };
});

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                    options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                    options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System").Build());
                    options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System").Build());
                }
                );




        }
        //   public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterModule<AutofacModuleRegister>();
        //}

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
               //   c.RoutePrefix = "";
                }

                );


            app.UseRouting();

            app.UseCors(DefaultCorsPolicyName);
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

     
    }
}
