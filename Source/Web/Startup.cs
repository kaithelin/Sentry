/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Dolittle.DependencyInversion.Autofac;
using Dolittle.Runtime.Events.Coordination;
using IdentityServer4;
using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        BootResult _bootResult;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddMvc();

            services.AddIdentityServer(options =>
                {
                    options.UserInteraction.LoginUrl = "/accounts/login";
                    options.UserInteraction.LogoutUrl = "/accounts/logout";
                    options.UserInteraction.ConsentUrl = "/accounts/consent";
                })

                //.AddEndpoint<DiscoveryEndpoint>("Discovery", "/tenant/.well-known/openid-configuration")
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryPersistedGrants()
                .AddProfileService<MyProfileService>();;

            /*
            var routerService = services.Single(_ => _.ServiceType == typeof(IEndpointRouter));
            services.Remove(routerService);
            MultiTenantEndpointRouter.OriginalEndpointRouterType = routerService.ImplementationType;
            services.Add(new ServiceDescriptor(typeof(IEndpointRouter), typeof(MultiTenantEndpointRouter), ServiceLifetime.Transient));
            */

            services.AddAuthentication()
                .AddOpenIdConnect("oidc", "Azure Active Directory", options =>
                {
                    options.CallbackPath = "/signin-oidc";
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                    // be4c4da6-5ede-405f-a947-8aedad564b7f

                    // https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-protocols-oidc

                    // https://login.microsoftonline.com/{tenant}/v2.0/.well-known/openid-configuration
                    //options.Authority = "https://login.microsoftonline.com/381088c1-de08-4d18-9e60-bbe2c94eccb5/v2.0";
                    options.Authority = "https://login.microsoftonline.com/common";

                    // organizations
                    options.ClientId = "Blah";
                    //options.ClientId = "2e2cad73-c11a-4d9f-8af9-beeebcdc5a27";
                    //options.ClientSecret = "jW6L65FIXZmsY6kIM+TKYws3zFJ03MyCAF9sFpIbFMs=";

                    //options.Events.RedirectToIdentityProvider

                    options.Events.OnRedirectToIdentityProvider = async(context)=>
                    {
                        /*
                        options.TokenValidationParameters.AudienceValidator = (IEnumerable<string> audiences, SecurityToken securityToken, TokenValidationParameters validationParameters) =>
                        {
                            
                            return true; 
                        };*/

                        //context.Options.TokenValidationParameters.
                        //context.Options.ClientId = "2e2cad73-c11a-4d9f-8af9-beeebcdc5a27";
                        context.ProtocolMessage.ClientId = "2e2cad73-c11a-4d9f-8af9-beeebcdc5a27";

                        await Task.CompletedTask;
                    };

                    options.Events.OnTokenResponseReceived = async(context)=>
                    {
                        await Task.CompletedTask;
                    };

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            _bootResult = services.AddDolittle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var committedEventStreamCoordinator = app.ApplicationServices.GetService(typeof(ICommittedEventStreamCoordinator))as ICommittedEventStreamCoordinator;
            committedEventStreamCoordinator.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // http://localhost:5000/fed43fa7-5279-4e72-9dbf-a344c17270e3/connect/authorize?client_id=mvc&redirect_uri=http%3A%2F%2Flocalhost%3A5002%2Fsignin-oidc&response_type=id_token&scope=openid%20profile%20nationalsociety&response_mode=form_post&nonce=636576009978909860.ZWM0OTAxOTUtMzA0YS00NGI3LTgyNTItNGUyYmYwNWNkOWI0OGNhZDJhZjEtZjI2YS00NjY1LWI0MjUtODYyMTBmZDVhNzA5&state=CfDJ8FkuBDQp5kBMuHK8ZpYHNkn8ujvBDCurPEFddBTQkowjY_0imbzRgHTv99iFVlFJ2tPOzxiCetxThElZJz3J5yHs31PLr1QX1ytMGAnc2xr-q_e07-F6TqZR-LcLPmDsKshlOYUGz_2xte8y7oF6IrB7_kWuK9gXj5cmxjt3ckMwUJ2LGt433Q5RIZFsXAThoyo6WLl1odpETZ5yZ_NZ-uAY_2Teqk3R_tvnA1CihcQPaknM4jLoSh_EW_2WASZxhsgT7RRU0wfLZPtrGR1-tKSdgkXqehAgOIKSQe9pY7NKBUtpB6dAvuIyYs-cGaLNsBLOJhuVer8SCN1IL9A4nMw&x-client-SKU=ID_NET&x-client-ver=2.1.4.0
            // http://localhost:5000/login.html?returnUrl=%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dmvc%26redirect_uri%3Dhttp%253A%252F%252Flocalhost%253A5002%252Fsignin-oidc%26response_type%3Did_token%26scope%3Dopenid%2520profile%2520nationalsociety%26response_mode%3Dform_post%26nonce%3D636576009978909860.ZWM0OTAxOTUtMzA0YS00NGI3LTgyNTItNGUyYmYwNWNkOWI0OGNhZDJhZjEtZjI2YS00NjY1LWI0MjUtODYyMTBmZDVhNzA5%26state%3DCfDJ8FkuBDQp5kBMuHK8ZpYHNkn8ujvBDCurPEFddBTQkowjY_0imbzRgHTv99iFVlFJ2tPOzxiCetxThElZJz3J5yHs31PLr1QX1ytMGAnc2xr-q_e07-F6TqZR-LcLPmDsKshlOYUGz_2xte8y7oF6IrB7_kWuK9gXj5cmxjt3ckMwUJ2LGt433Q5RIZFsXAThoyo6WLl1odpETZ5yZ_NZ-uAY_2Teqk3R_tvnA1CihcQPaknM4jLoSh_EW_2WASZxhsgT7RRU0wfLZPtrGR1-tKSdgkXqehAgOIKSQe9pY7NKBUtpB6dAvuIyYs-cGaLNsBLOJhuVer8SCN1IL9A4nMw%26x-client-SKU%3DID_NET%26x-client-ver%3D2.1.4.0

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //var routeBuilder = new RouteBuilder(app);
            //var guidRegex = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";

            //var guidRegex = @"[\da-zA-Z]{{8}}-([\da-zA-Z]{{4}}-){{3}}[\da-zA-Z]{{12}}";
            // :regex("+guidRegex+");
            //routeBuilder.MapMiddlewareRoute("{tenant:regex("+guidRegex+")}/{*pathInfo}", _ => _.UseMiddleware<TenantExtractorMiddleware>());
            //app.UseRouter(routeBuilder.Build());

            app.UseMiddleware<TenantMiddleware>();
            app.UseIdentityServer();

            // Keep this last as this is the fallback when nothing else works - spit out the index file           
            app.Run(async context =>
            {
                context.Request.Path = new PathString("/");
                var path = $"{env.ContentRootPath}/wwwroot/index.html";
                await context.Response.SendFileAsync(new PhysicalFileInfo(new FileInfo(path)));
            });            
        }
    }
}