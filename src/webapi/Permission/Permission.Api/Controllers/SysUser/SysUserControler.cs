using System.Collections.Generic;
using Common.Message;
using Microsoft.AspNetCore.Mvc;
using Permission.Entity;

namespace Permission.Api.Controllers
{

    /// <summary>
    /// 用户信息
    /// </summary>
    [ApiController]
    [Route("/api/permission/user/")]
    public class SysUserControler : BaseController
    {

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="sysUser">用户信息</param>
        /// <returns></returns>
        [HttpPost("add")]
        public RestResponse Insert([FromBody] SysUser sysUser)
        {
            return RestResponse.success();
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public RestResponse Get(string id)
        {
            SysUser sysUser = new SysUser();
            return RestResponse.success().put("model", sysUser);
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public RestResponse Update([FromBody] SysUser sysUser)
        {
            int flag = 0;
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public RestResponse DeleteById(string id)
        {
            int flag = 0;
            return flag > 0 ? RestResponse.success() : RestResponse.error("操作失败");
        }


        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        [HttpGet("list/{page}/{limit}")]
        public RestResponse QueryList(int page = 1, int limit = 10)
        {
            IList<SysUser> sysUserList = new List<SysUser>();
            return RestResponse.success().put("page", sysUserList);
        }


    }
}