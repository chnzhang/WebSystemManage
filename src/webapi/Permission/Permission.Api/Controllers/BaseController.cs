using Microsoft.AspNetCore.Mvc;

namespace Permission.Api.Controllers
{
    /// <summary>
    /// 用户信息基类
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 用户登录token
        /// </summary>
        /// <value></value>
        //protected SysUserTokenService _SysUserTokenService;

        /// <summary>
        /// 用户信息
        /// </summary>
       // protected SysUserService _SysUserService;

        /// <summary>
        /// 用户基类注入
        /// </summary>
        public BaseController()
        {
          //  _SysUserTokenService = Startup.ServiceProvider.GetService(typeof(SysUserTokenService)) as SysUserTokenService;
           // _SysUserService = Startup.ServiceProvider.GetService(typeof(SysUserService)) as SysUserService;
        }




        /// <summary>
        /// 用户信息
        /// </summary>
        //private SysUser sysUser;


        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        // public new SysUser User
        // {
        //     get
        //     {
        //         if (sysUser == null)
        //         {
        //             string token = Filters.GlobalFilter.GetRequestToken(this.Request);
        //             if (!string.IsNullOrEmpty(token))
        //             {
        //                 SysUserToken sysUserToken = _SysUserTokenService.SysUserTokenRepository.GetEntity(new { Token = token, ExpireTime = DateTime.Now });
        //                 if (sysUserToken != null)
        //                     sysUser = _SysUserService.SysUserRepository.GetById(sysUserToken.UserId);
        //             }
        //         }
        //         return sysUser;
        //     }
        //     set
        //     {
        //         sysUser = value;
        //     }
        // }
    }
}