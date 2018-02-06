using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using HYC.WebApi.swagger;
using HYC.Common;
using System.Reflection;

namespace HYC.WebApi
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
            //通过选项配置获取数据库连接信息 
            services.AddOptions();
            services.Configure<SqlHelper>(Configuration.GetSection("ConnectionStrings"));

            //依赖注入模块(HYC.Service,HYC.Repository)
            AddScopeds(services);

            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                c.IncludeXmlComments(Path.Combine(basePath, "model.xml"));
                c.IncludeXmlComments(Path.Combine(basePath, "webapimodel.xml"));
                c.OperationFilter<SwaggerFilter>();
                c.DocumentFilter<HiddenFilter>();
                c.AddSecurityDefinition("dev", new ApiKeyScheme
                {
                    Name = "X-Access-Token",
                    In = "header"
                });
            });

            //跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://192.168.1.162:8080");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });




            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// 自动处理依赖注入(每个方法都用接口调用,因此每个类的实现都需要继承接口)
        /// </summary>
        /// <param name="services"></param>
        private void AddScopeds(IServiceCollection services)
        {
            //依赖注入HYC.Service
            Assembly assembly = Assembly.Load("HYC.Service");
            Type[] types = assembly.GetTypes();
            foreach (var t in types)
            { 
               Type[] itypes= t.GetInterfaces();
                foreach (var it in itypes)
                {
                    services.AddScoped(it, t);
                }
            }

            //依赖注入HYC.Repository
            assembly = Assembly.Load("HYC.Repository");
            types = assembly.GetTypes();
            foreach (var t in types)
            {
                Type[] itypes = t.GetInterfaces();
                foreach (var it in itypes)
                {
                    services.AddScoped(it, t);
                }
            }
        }
    }
}
