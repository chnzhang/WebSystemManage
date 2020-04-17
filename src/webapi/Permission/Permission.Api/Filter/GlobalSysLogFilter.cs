using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Permission.Entity;
using Permission.Service;

namespace Permission.Api.Filter
{
    public class GlobalSysLogFilter : IActionFilter
    {

        private SysLogOperationService _SysLogService { get; }

        private IHttpContextAccessor _accessor { get; }

        private string Params { get; set; }

        /// <summary>
        /// 用户登录token
        /// </summary>
        /// <value></value>
        protected SysUserTokenService _SysUserTokenService { get; }

    

        public GlobalSysLogFilter(SysLogOperationService SysLogService, IHttpContextAccessor accessor, SysUserTokenService SysUserTokenService)
        {
            this._SysLogService = SysLogService;
            _accessor = accessor;
            this._SysUserTokenService = SysUserTokenService;         
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            //写日志
            string Operation = GetCustomerData(((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).MethodInfo);
            if (!string.IsNullOrEmpty(Operation))
            {
                SysLogOperation log = new SysLogOperation();
                log.Id = System.Guid.NewGuid().ToString("N");

                //获取方法
                log.Method = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).DisplayName;
                log.Method = log.Method.Replace("(Permission.API)", "()");
                log.SysUserAccountId = "";
                //获取用户信息  
                string token = GlobalAuthorizationFilter.GetRequestToken(context.HttpContext.Request);
                if (!string.IsNullOrEmpty(token))
                {
                    SysUserToken sysUserToken = _SysUserTokenService.SysUserTokenRepository.GetEntity(new { Token = token, ExpireTime = DateTime.Now });
                    if (sysUserToken != null)
                    {
                        log.SysUserAccountId = sysUserToken.SysUserAccountId;
                    }
                }


                //获取参数
                log.Params = Params;
                if (Params.Length > 1000)
                {
                    log.Params = log.Params.Substring(0, 1000);
                }

                //获取ip信息
                log.Ip = _accessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();

                //获取执行时间
                var renderTimer = GetTimer(context.HttpContext, "render");
                renderTimer.Stop();
                log.Time = (int)renderTimer.ElapsedMilliseconds;

                //当前时间
                log.CreateTime = DateTime.Now;
                //内容
                log.Operation = Operation;
                _SysLogService.Insert(log);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new System.NotImplementedException();
            string RequiresPermissions = GetCustomerData(((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).MethodInfo);
            if (!string.IsNullOrEmpty(RequiresPermissions))
            {

                //获取参数
                var method = context.HttpContext.Request.Method.ToUpper();
                if ("POST".Equals(method))
                {

                    Params = JsonConvert.SerializeObject(context.ActionArguments.Values);

                }
                else if ("GET".Equals(method))
                {
                    var para = new
                    {
                        url = context.HttpContext.Request.Path,
                        param = context.HttpContext.Request.QueryString
                    };

                    Params = JsonConvert.SerializeObject(para);
                }



                GetTimer(context.HttpContext, "render").Start();
            }
        }


        private Stopwatch GetTimer(HttpContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.Items.Keys.Contains(key))
            {
                return (Stopwatch)context.Items[key];
            }

            var result = new Stopwatch();
            context.Items[key] = result;
            return result;
        }


        /// <summary>
        /// 获取日志标记
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public string GetCustomerData(System.Reflection.MethodInfo action)
        {

            string content = string.Empty;
            var queue = action.GetCustomAttributesData().Where(w => w.AttributeType == typeof(SysLogAttribute)).FirstOrDefault();
            if (queue != null)
            {
                content = queue.ConstructorArguments.FirstOrDefault().Value.ToString();
            }
            return content;
        }


    }
}