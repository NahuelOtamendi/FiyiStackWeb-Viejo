using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FiyiStackWeb.Areas.BasicCore.Interfaces;
using FiyiStackWeb.Areas.CMSCore.Interfaces;
using FiyiStackWeb.Areas.BasicCore.Services;
using FiyiStackWeb.Areas.CMSCore.Services;
using FiyiStackWeb.Library;
using System;
using FiyiStackWeb.Areas.FiyiStack.Interfaces;
using FiyiStackWeb.Areas.FiyiStack.Services;
using FiyiStackWeb.Areas.BasicCulture.Services;
using FiyiStackWeb.Areas.BasicCulture.Interfaces;

namespace FiyiStackWeb
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
            services.AddHttpClient();
            services.AddRazorPages();
            services.AddControllers();

            //JSON to TimeSpan configuration
            services.AddControllers()
        .AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonToTimeSpan()));

            //JSON configuration to output field names in PascalCase. Example: "TestId" : 1 and not "testId" : 1
            services.AddControllers()
        .AddJsonOptions(options =>
            options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddHttpContextAccessor();

            //Area: BasicCore
            services.AddScoped<IFailure, FailureService>();
            services.AddScoped<IParameter, ParameterService>();
            services.AddScoped<IVisitorCounter, VisitorCounterService>();
            //Area: BasicCulture
            services.AddScoped<ICity, CityService>();
            services.AddScoped<IProvince, ProvinceService>();
            services.AddScoped<ICountry, CountryService>();
            services.AddScoped<IPlanet, PlanetService>();
            services.AddScoped<ISex, SexService>();
            //Area: CMSCore
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IMenu, MenuService>();
            services.AddScoped<IRoleMenu, RoleMenuService>();
            services.AddScoped<IRole, RoleService>();
            //Area: FiyiStack
            services.AddScoped<IFiyiStack, FiyiStackService>();
            services.AddScoped<IBlog, BlogService>();
            services.AddScoped<ICommentForBlog, CommentForBlogService>();
            services.AddScoped<ISendUsDBDiagram, SendUsDBDiagramService>();

            services.AddMvc();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    context.HttpContext.Response.Redirect("/404");
                }
            });

        }
    }
}
