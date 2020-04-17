using System;
using Common.Message;
using Microsoft.AspNetCore.Mvc;
using Permission.Entity;
using Permission.Service;

namespace Permission.Api.Controllers.SysUser
{

    /// <summary>
    /// 令牌信息
    /// </summary>
    [ApiController]
    [Route("/api/permission/token/")]
    public class SysUserTokenController : BaseController
    {
        private readonly SysUserTokenService sysUserTokenService;
        public SysUserTokenController(SysUserTokenService _sysUserTokenService)
        {
            sysUserTokenService = _sysUserTokenService;
        }


        /// <summary>
        /// 设置Token过期
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        [HttpPost]
        public RestResponse ExpireToken(string token)
        {
            SysUserToken sysUserToken = sysUserTokenService.GetEntity(new { Token = token });
            if (sysUserToken == null)
            {
                return RestResponse.validate("未找到token");
            }

            sysUserToken.ExpireTime = DateTime.Now;
            int flag = sysUserTokenService.Update(sysUserToken);

            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");

        }


         /// <summary>
        /// 设置Token过期
        /// </summary>
        /// <param name="sysUserAccountId">用户id</param>
        /// <returns></returns>
        [HttpPost]
        public RestResponse ExpireToken(int sysUserAccountId)
        {
            SysUserToken sysUserToken = sysUserTokenService.GetEntity(new { SysUserAccountId = sysUserAccountId });
            if (sysUserToken == null)
            {
                return RestResponse.validate("未找到帐号");
            }

            sysUserToken.ExpireTime = DateTime.Now;
            int flag = sysUserTokenService.Update(sysUserToken);

            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");

        }

     
    }
}