//*******************************
// Create By cnzhang
// Date 2020-04-14 15:30
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_user_token
    ///</summary>
    public class SysUserToken
    {
        ///<summary>
        /// ID, varchar
        ///</summary>
        public virtual string Id { get; set; }
        ///<summary>
        /// 账号id
        ///</summary>
        public virtual string SysUserAccountId { get; set; }
        ///<summary>
        /// 令牌
        ///</summary>
        public virtual string Token { get; set; }
        ///<summary>
        /// 失效时间
        ///</summary>
        public virtual DateTime ExpireTime { get; set; }
        ///<summary>
        /// 更新时间
        ///</summary>
        public virtual DateTime UpdateTime { get; set; }
    }
}

