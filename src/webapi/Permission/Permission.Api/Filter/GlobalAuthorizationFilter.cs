using System;
using System.Linq;
using Common.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Permission.Entity;
using Permission.Service;

namespace Permission.Api.Filter
{
    public class GlobalAuthorizationFilter : Attribute, IAuthorizationFilter
    {

        /// <summary>
        /// 用户登录token
        /// </summary>
        /// <value></value>
        public SysUserTokenService _SysUserTokenService { get; set; }
        public GlobalAuthorizationFilter(SysUserTokenService SysUserTokenService)
        {
            _SysUserTokenService = SysUserTokenService;
        }


        /// <summary>
        /// 授权检测
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //判断是否跳过授权过滤器   

            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return;
            }


            if (context.Filters.Any(item => item is IAllowAnonymousFilter)) return;

            //获取请求token，如果token不存在，直接返回401
            string token = GetRequestToken(context.HttpContext.Request);
            if (string.IsNullOrEmpty(token))
            {
                context.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                context.Result = new JsonResult(RestResponse.error(HttpStatus.UNAUTHORIZED, "invalid token"));
                return;
            }

            //验证token的有效性
            SysUserToken sysUserToken = _SysUserTokenService.SysUserTokenRepository.GetEntity(new { Token = token, ExpireTime = DateTime.Now });
            if (sysUserToken == null)
            {
                context.HttpContext.Response.Headers["Access-Control-Allow-Credentials"] = "true";
                context.Result = new JsonResult(RestResponse.error(HttpStatus.UNAUTHORIZED, "invalid token"));
                return;
            }

            //验证当前用户是否有权限访问该方法
            string apiUrl = context.HttpContext.Request.RouteValues.FirstOrDefault().ToString();


        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetRequestToken(HttpRequest request)
        {
            //从header中获取token
            string token = request.Headers["token"];
            if (string.IsNullOrEmpty(token))
            {
                //从参数获取token
                token = request.Query["token"];
                if (string.IsNullOrEmpty(token))
                {
                    //从cookies获取
                    token = request.Cookies["token"];
                }
            }
            if (token != null && token.Equals("undefined"))
            {
                token = "";
            }

            return token;
        }

        // /// <summary>
        // /// 获取权限标记
        // /// </summary>
        // /// <param name="action"></param>
        // /// <returns></returns>
        // public Tuple<string[], int> GetCustomerData(System.Reflection.MethodInfo action)
        // {

        //     string[] authcode = null;
        //     int level = 0;
        //     var queue = action.GetCustomAttributesData().Where(w => w.AttributeType == typeof(RequiresPermissionsAttribute)).FirstOrDefault();
        //     if (queue != null)
        //     {
        //         authcode = queue.ConstructorArguments.FirstOrDefault().Value.ToString().Split(";");
        //         level = Convert.ToInt32(queue.ConstructorArguments.LastOrDefault().Value);
        //     }
        //     return new Tuple<string[], int>(authcode, level);
        // }



        // /// <summary>
        // /// 用户权限判断
        // /// </summary>
        // /// <param name="userId">用户id</param>
        // /// <param name="authcode">权限代码</param>
        // /// <param name="level">验证等级</param>
        // /// <returns></returns>
        // public bool GetPermission(string userId, string[] authcode, int level)
        // {
        //     foreach (var pe in authcode)
        //     {
        //         //查询用户权限
        //         switch (level)
        //         {
        //             case (int)Level.Operation:
        //                 //查询用户操作权限
        //                 //查询用户所拥有的权限
        //                 SysMenu sysMenu = _SysMenuService.GetSysMenuByPerms(userId, pe);
        //                 if (sysMenu != null)
        //                     return true;
        //                 break;
        //             case (int)Level.Permissions:
        //                 break;
        //             case (int)Level.Role:
        //                 break;
        //         }
        //     }

        //     return false;
        // }
    }
}