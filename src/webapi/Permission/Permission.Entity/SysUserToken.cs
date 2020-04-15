//*******************************
// Create By cnzhang
// Date 2020-04-14 15:30
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
using Common;

namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_user_token
    ///</summary>
    public class SysUserToken:BaseEntity
    {

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

