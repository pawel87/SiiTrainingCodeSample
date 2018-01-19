using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiiTraining.Code.Services;
using SiiTraining.Code.Routes;
using Microsoft.AspNetCore.Routing;
using SiiTraining.Code.Binding;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Text;
using SiiTraining.Code.Middleware;

namespace SiiTraining
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Production environment version of "ConfigureServices" method
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency Injection for Filter
            services.AddScoped<IFilterDiagnostics, BasicFilterDiagnostics>();

            services.AddScoped<IRepository, MemoryRepository>();

            services.AddScoped<IDateService, DateService>();

            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

            #region Globalization

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("pl-PL"),
                    new CultureInfo("en-US")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "pl-PL", uiCulture: "pl-PL");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion  

            #region Cache

            //services.AddMemoryCache();

            //services.AddDistributedMemoryCache();

            //services.AddDistributedRedisCache((x) => x.Configuration = ...);


            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "127.0.0.1";
            //    option.InstanceName = "master";
            //});

            services.AddResponseCaching();
            

            //services.AddResponseCaching();

            //services.AddResponseCaching(options =>
            //{
            //    options.UseCaseSensitivePaths = true;
            //    options.MaximumBodySize = 1024;
            //});

            #endregion


            #region ModelBinder

            services.AddMvc(o =>
            {
                o.ModelBinderProviders.Insert(0, new DateAndTimeModelBinderProvider());
            });

            #endregion
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region Caching

            //app.UseResponseCaching();

            #endregion

            #region Middleware

            //sample1
            //app.Run(async (context) =>
            //{
            //    var text = "Hello World from inline middleware 1!";
            //    var bytes = Encoding.ASCII.GetBytes(text);
            //    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            //});


            //sample 2

            //app.Use(async (context, next) =>
            //{
            //    //write logic which does NOT write to response (when calling next.Invoke())
            //    //Console.WriteLine("Inline middleware call");

            //    var text = "Hello World from inline middleware 1!";
            //    var bytes = Encoding.ASCII.GetBytes(text);
            //    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    var text = "Hello World from inline middleware 2!";
            //    var bytes = Encoding.ASCII.GetBytes(text);
            //    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            //    //middleware logic here
            //});

            //sample 3

            //app.UseMiddleware<SampleMiddleware>();

            //app.UseSampleMiddleware();

            // sample 4

            //app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            //{
            //    app.UseSampleMiddleware();
            //});
            #endregion

            #region GlobalizationSettings
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("pl-PL"),
                new CultureInfo("en-US")
            };

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("pl-PL"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            //options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
            //{
            //    //custom request culture logic here
            //    return new ProviderCultureResult("pl");
            //}));


            app.UseRequestLocalization(options);

#endregion

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "BindingModel",
                //    template: "{controller=Binding}/{action=BindExample}/{category}",
                //    defaults: null,
                //    constraints: null,
                //    dataTokens: new { Name = "binding_model" }
                //    );

                //routes.MapRoute(
                //    name: "DataTokenExample",
                //    template: "{controller=Routes}/{action=ActionWithToken}",
                //    defaults: null,
                //    constraints: null,
                //    dataTokens: new { Name = "binding_model" }
                //    );



                //routes.MapRoute(
                //  name: "CustomRouteConstraintInline",
                //  template: "Routes/CustomConstraintInline/{day:weekday?}"
                //);

                //routes.MapRoute(
                //  name: "CustomRouteConstraint",
                //  template: "{controller}/{action}/{day?}",
                //  defaults: new { controller = "Routes", action = "CustomConstraint" },
                //  constraints: new { day = new WeekDayConstraint() }
                //);


                //routes.MapRoute(
                //    name: "regexRoute",
                //    template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");


                //routes.MapRoute(
                //    name: "myRoute",
                //    template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");

                //routes.MapRoute(
                //    name: "myRoute",
                //    template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");

                //routes.MapRoute(
                //    name: "myRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new
                //    {
                //        id = new CompositeRouteConstraint(new IRouteConstraint[]
                //            {
                //                new AlphaRouteConstraint(),
                //                new MinLengthRouteConstraint(6)
                //            })

                //    });


                routes.MapRoute(
                    name: "BindingModel",
                    template: "{controller=Binding}/{action=BindExample}/{category}");

                

                //routes.MapRoute(
                //    name: "componentRoute",
                //    template: "{controller=Component}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");


                //routes.MapRoute(
                //    name: "default",
                //    template: "klienci/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
