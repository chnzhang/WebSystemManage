using System;
using System.Collections.Generic;
using Common;
using Common.Message;
using Hei.Captcha;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permission.Api.Filter;
using Permission.Api.Model;
using Permission.Entity;
using Permission.Entity.Enum;
using Permission.Service;
using static NetDataAnnotations.BaseModelType;

namespace Permission.Api.Controllers.SysUser
{

    /// <summary>
    /// 帐号信息
    /// </summary>
    [ApiController]
    [Route("/api/permission/account/")]
    public class SysUserAccountController : BaseController
    {
        private readonly SysUserAccountService sysUserAccountService;
        private readonly SysUserTokenService sysUserTokenService;
        private readonly SysLogLoginService sysLogLoginService;
        private readonly IHttpContextAccessor accessor;

        public SysUserAccountController(SysUserAccountService _sysUserAccountService,
        SysUserTokenService _sysUserTokenService,
        SysLogLoginService _sysLogLoginService,
        IHttpContextAccessor _accessor)
        {
            sysUserAccountService = _sysUserAccountService;
            sysUserTokenService = _sysUserTokenService;
            sysLogLoginService = _sysLogLoginService;
            accessor = _accessor;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns>登录令牌</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public RestResponse Login([FromBody] LoginModel login)
        {
            //验证 验证码
            HttpContext.Session.TryGetValue("captcha", out var captch);
            if (captch == null)
            {
                return RestResponse.validate("验证码错误,请刷新验证码重试");
            }
            string Captcha = System.Text.Encoding.Default.GetString(captch);
            if (string.IsNullOrEmpty(Captcha) || !login.Code.Equals(Captcha))
            {
                return RestResponse.validate("验证码错误");
            }

            //验证 用户名、密码
            SysUserAccount account = sysUserAccountService.GetEntity(new
            {
                LoginAccount = login.Account
            });

            if (account == null)
            {
                return RestResponse.validate("帐号/密码错误");
            }

            //比较密码
            string password = Common.EncryptionDecryption.Md5Unit.MD532(login.Password + account.Salt);
            if (!password.Equals(account.Password))
            {
                return RestResponse.validate("帐号/密码错误");
            }

            //查询是否被禁用
            if (account.Status == (int)CommonEnum.STATUS.DISABLE)
            {
                return RestResponse.error("您的帐号已被禁止使用,请联系客服");
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

            //写入登录日志
            SysLogLogin log = new SysLogLogin();
            log.SysUserAccountId = account.Id;
            log.Ip = accessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
            sysLogLoginService.Insert(log);

            //清空验证码
            HttpContext.Session.Remove("captcha");
            return RestResponse.success().put("token", token);
        }


        /// <summary>
        /// 新增帐号
        /// </summary>
        /// <param name="sysUser">用户信息</param>
        /// <returns></returns>
        [HttpPost("add")]
        [Insert]//设置验证规则group
        [SysLog("新增帐号")]
        public RestResponse Insert([FromBody] SysUserAccount sysUserAccount)
        {
            //验证帐号是否可用
            SysUserAccount sysUserAccountEntity = sysUserAccountService.GetEntity(new { LoginAccount = sysUserAccount.LoginAccount });
            if (sysUserAccountEntity != null)
            {
                return RestResponse.validate("用户名已存在");
            }
            //可以此自己处理帐号与用户信息关联           
            sysUserAccount.Salt = Guid.NewGuid().ToString("N");
            sysUserAccount.Password = Common.EncryptionDecryption.Md5Unit.MD532(sysUserAccount.Password + sysUserAccount.Salt);
            sysUserAccount.UpdateTime = DateTime.Now;
            sysUserAccount.Status = (int)CommonEnum.STATUS.ENABLE;

            int flag = sysUserAccountService.Insert(sysUserAccount);
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 帐号信息是否可用
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <returns></returns>
        public RestResponse IsUseAccount(string loginAccount)
        {
            //验证帐号是否可用
            SysUserAccount sysUserAccount = sysUserAccountService.GetEntity(new { LoginAccount = loginAccount });
            if (sysUserAccount != null)
            {
                return RestResponse.validate("用户名已存在");
            }
            else
            {
                return RestResponse.success();
            }
        }



        /// <summary>
        /// 获取帐号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public RestResponse Get(string id)
        {
            SysUserAccount sysUserAccount = sysUserAccountService.GetById(id);
            return RestResponse.success().put("model", sysUserAccount);
        }


        /// <summary>
        /// 修改帐号信息
        /// </summary>
        /// <param name="sysUserAccount"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [Update]
        public RestResponse Update([FromBody] SysUserAccount sysUserAccount)
        {
            SysUserAccount sysUserAccountEntity = sysUserAccountService.GetEntity(new { LoginAccount = sysUserAccount.LoginAccount });
            if (sysUserAccount != null && !sysUserAccountEntity.Id.Equals(sysUserAccount.Id))
            {
                return RestResponse.validate("用户名已存在");
            }

            int flag = sysUserAccountService.Update(sysUserAccount);
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 删除帐号信息
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public RestResponse DeleteById(string id)
        {
            int flag = sysUserAccountService.DeleteById(id);
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
            Pager pager = new Pager(page, limit);

            QueryPageResponse sysUserList = sysUserAccountService.QueryByPage(pager);
            return RestResponse.success().put("page", sysUserList);
        }


    }
}