using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using mgmoarticleconnector;
using mgmoexampleconnector;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace mgmoapi
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            var config = new AppConfig();

            Configuration.Bind(config);

            services.AddSingleton(config);

            services.AddControllers();

            //c.OAuthClientId(config?.AzureAd?.ClientId);
            //c.OAuthScopes("openid", "profile", "email", $"{config.AzureAd.Audience}/access_as_user");
            //c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>()
            //    {
            //        { "audience", config?.AzureAd?.Audience}
            //    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mgmoapi", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri($"https://login.microsoftonline.com/db7ec873-9a15-4867-811d-6e8557a797b9/oauth2/v2.0/token"),
                            AuthorizationUrl = new Uri($"https://login.microsoftonline.com/db7ec873-9a15-4867-811d-6e8557a797b9/oauth2/v2.0/authorize"),
                            Scopes = new Dictionary<string, string>
                            {
                                        {
                                            "openid",
                                            "Reads the Weather forecast"
                                        },
                                                {
                                                    "profile", "test"
                                                },
                                                {
                                                    "email",
                                                    "test"
                                                }
                                    }
                        }
                        }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Name = "Token",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Token",
                            },
                        },
                        Array.Empty<string>()
                     }
                });
                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows()
                //    {
                //        Implicit = new OpenApiOAuthFlow()
                //        {
                //            AuthorizationUrl = new Uri("https://login.microsoftonline.com/db7ec873-9a15-4867-811d-6e8557a797b9/oauth2/v2.0/authorize"),
                //            TokenUrl = new Uri("https://login.microsoftonline.com/db7ec873-9a15-4867-811d-6e8557a797b9/oauth2/v2.0/token"),
                //            Scopes = new Dictionary<string, string> {
                //        {
                //            "openid",
                //            "Reads the Weather forecast"
                //        },
                //                {
                //                    "profile", "test"
                //                },
                //                {
                //                    "email",
                //                    "test"
                //                }
                //    }
                //        }
                //    }
                //});

            });

            
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterModule(new ArticlesModule(Configuration));
            builder.RegisterModule(new ExamplesModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppConfig config)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "mgmoapi v1");
                    c.RoutePrefix = string.Empty;
                    c.OAuthClientId(config?.AzureAd?.ClientId);
                    c.OAuthScopes("openid", "profile", "email", $"api://5144946a-e715-465e-af13-046e05fc94ae/access_as_user");
                    c.OAuthScopeSeparator(" ");
                    //    c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>()
                    //{
                    //    { "audience", config?.AzureAd?.Audience}
                    //});

                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
