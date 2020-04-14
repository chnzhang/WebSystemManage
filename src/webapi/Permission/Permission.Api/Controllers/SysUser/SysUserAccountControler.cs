using System.Collections.Generic;
using Common.Message;
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
        private SysUserAccountService sysUserAccountService { get; }
        public SysUserAccountControler(SysUserAccountService _sysUserAccountService)
        {
            sysUserAccountService = _sysUserAccountService;
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

            //验证 用户名、密码
            SysUserAccount account = sysUserAccountService.GetEntity(new
            {
                Account = login.Account
            });

            if (account == null)
            {
                return RestResponse.error("帐号错误");
            }

            string password = Common.EncryptionDecryption.Md5Unit.MD532(login.Password + account.Salt);
            if (!password.Equals(account.Password))
            {
                return RestResponse.error("密码错误");
            }

            //生成token
            
            return RestResponse.success().put("token", "");
        }


        /// <summary>
        /// 新增帐号
        /// </summary>
        /// <param name="sysUser">用户信息</param>
        /// <returns></returns>
        [HttpPost("add")]
        public RestResponse Insert([FromBody] SysUserAccount sysUser)
        {
            //可以此自己处理帐号与用户信息关联
            return RestResponse.success();
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