//*******************************
// Create By ZhangGuangZhi
// Date 2019-09-27 15:01
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using Common.Message;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Permission.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(IWebHostEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var exception = context.Exception;

            if (exception is System.Text.DecoderFallbackException)
            {
                //暂未找到该异常处理方法
            }
            else
            {
                logger.LogError(
                new EventId(exception.HResult),
                exception,
                exception.ToString());
            }

            var errorResp = RestResponse.error();

            var result = new JsonResult(errorResp)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            context.Result = result;
        }


        /// <summary>
        /// 异步发生异常时进入
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }




    }
}






