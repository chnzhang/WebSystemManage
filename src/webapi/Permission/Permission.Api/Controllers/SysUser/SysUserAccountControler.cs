using System;
using System.Collections.Generic;
using Common;
using Common.Message;
using Hei.Captcha;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permission.Api.Model;
using Permission.Entity;
using Permission.Service;

namespace Permission.Api.Controllers
{

    /// <summary>
    /// 帐号信息
    /// </summary>
    [ApiController]
    [Route("/api/permission/account/")]
    public class SysUserAccountControler : BaseController
    {
        private readonly SysUserAccountService sysUserAccountService;
        private readonly SysUserTokenService sysUserTokenService;

        public SysUserAccountControler(SysUserAccountService _sysUserAccountService, SysUserTokenService _sysUserTokenService)
        {
            sysUserAccountService = _sysUserAccountService;
            sysUserTokenService = _sysUserTokenService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns>登录令牌</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public RestResponse Login([FromBody] LoginModel login)
        {
            //验证 验证码
            HttpContext.Session.TryGetValue("captcha", out var captch);
            if (captch == null)
            {
                return RestResponse.error("验证码错误,请刷新验证码重试");
            }
            string Captcha = System.Text.Encoding.Default.GetString(captch);
            if (string.IsNullOrEmpty(Captcha) || !login.Code.Equals(Captcha))
            {
                return RestResponse.error("验证码错误");
            }

            //验证 用户名、密码
            SysUserAccount account = sysUserAccountService.GetEntity(new
            {
                LoginAccount = login.Account
            });

            if (account == null)
            {
                return RestResponse.error("帐号/密码错误");
            }

            string password = Common.EncryptionDecryption.Md5Unit.MD532(login.Password + account.Salt);
            if (!password.Equals(account.Password))
            {
                return RestResponse.error("帐号/密码错误");
            }

            //生成token
            string token = TokenGenerator.generateValue();

            SysUserToken userToken = sysUserTokenService.GetEntity(new
            {
                SysUserAccountId = account.Id
            });

            userToken = userToken == null ? new SysUserToken() : userToken;
            userToken.SysUserAccountId = account.Id;
            userToken.Token = token;
            //查询配置 令牌时效
            double h = Convert.ToDouble(Startup.Configuration["Token:TimeHourExpire"]);
            userToken.ExpireTime = DateTime.Now.AddHours(h);
            userToken.UpdateTime = DateTime.Now;

            int flag = string.IsNullOrEmpty(userToken.Id) ? sysUserTokenService.Insert(userToken) : sysUserTokenService.Update(userToken);


            return RestResponse.success().put("token", token);
        }


        /// <summary>
        /// 新增帐号
        /// </summary>
        /// <param name="sysUser">用户信息</param>
        /// <returns></returns>
        [HttpPost("add")]
        public RestResponse Insert([FromBody] SysUserAccount sysUser)
        {
            //验证帐号是否可用
            SysUserAccount sysUserAccount = sysUserAccountService.GetEntity(new { LoginAccount = sysUser.LoginAccount });
            if (sysUserAccount != null)
            {
                return RestResponse.error("用户名已存在");
            }
            //可以此自己处理帐号与用户信息关联           
            sysUser.Salt = Guid.NewGuid().ToString("N");
            sysUser.Password = Common.EncryptionDecryption.Md5Unit.MD532(sysUser.Password + sysUser.Salt);
            sysUser.UpdateTime = DateTime.Now;

            int flag = sysUserAccountService.Insert(sysUser);
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 获取帐号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public RestResponse Get(string id)
        {
            SysUserAccount sysUser = new SysUserAccount();
            return RestResponse.success().put("model", sysUser);
        }


        /// <summary>
        /// 修改帐号信息
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public RestResponse Update([FromBody] SysUserAccount sysUser)
        {
            int flag = 0;
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 删除帐号信息
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public RestResponse DeleteById(string id)
        {
            int flag = 0;
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 帐号列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        [HttpGet("list/{page}/{limit}")]
        public RestResponse QueryList(int page = 1, int limit = 10)
        {
            IList<SysUserAccount> sysUserList = new List<SysUserAccount>();
            return RestResponse.success().put("page", sysUserList);
        }


    }
}