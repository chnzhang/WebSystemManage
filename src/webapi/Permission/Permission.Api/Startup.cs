using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Permission.Api.Filter;
using Hei.Captcha;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetDataAnnotations;

namespace Permission.Api
{
    public class Startup
    {
        const string SERVICE_NAME = "Permission.API";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers((opt =>
            {
                opt.RespectBrowserAcceptHeader = true;
                //全局模型校验注册
                opt.Filters.Add<GlobalActionFilterAttribute>();
                //全局权限拦截器
                opt.Filters.Add<GlobalAuthorizationFilter>();
                //全局异常拦截器注册
                opt.Filters.Add<GlobalExceptionFilter>();
                //全局操作日志拦截器注册
                opt.Filters.Add<GlobalSysLogFilter>();

            }));

            RegisterRepository(services);
            RegisterService(services);

            //验证码
            services.AddHeiCaptcha();


            //参数验证
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    StringBuilder errStr = new StringBuilder();

                    var erroList = context.ModelState.ToList();
                    if (erroList.Any())
                    {
                        errStr.AppendFormat("{0}", erroList.LastOrDefault().Value.Errors.FirstOrDefault().ErrorMessage);
                        // foreach (var item in erroList)
                        // {
                        //     // errStr.AppendFormat("{0}:{1} |", item.Key, item.Value.Errors.FirstOrDefault().ErrorMessage);
                        //     errStr.AppendFormat("{0}|", item.Value.Errors.FirstOrDefault().ErrorMessage);                            
                        // }
                    }
                    var resp = Common.Message.RestResponse.validate(errStr.ToString().TrimEnd('|'));
                    return new JsonResult(resp);
                };
            });





            //获取ip地址
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //开启Session
            services.AddDistributedMemoryCache().AddSession();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        private void RegisterRepository(IServiceCollection services)
        {
            services.AddSmartSql()
            .AddRepositoryFromAssembly(options =>
            {
                options.AssemblyString = "Permission.Repository";
            });
        }
        private void RegisterService(IServiceCollection services)
        {
            var assembly = Assembly.Load("Permission.Service");
            var allTypes = assembly.GetTypes();
            foreach (var type in allTypes)
            {
                services.AddSingleton(type);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // app.UseHttpsRedirection();


            app.UseSession();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();               
            });


        }
    }
}
