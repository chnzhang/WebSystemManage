//*******************************
// Create By cnzhang
// Date 2020-04-17 11:59
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
using Common;

namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_log_login
    ///</summary>
    public class SysLogLogin:BaseEntity
    {
      
        ///<summary>
        /// SYS_USER_ACCOUNT_ID, varchar
        ///</summary>
        public virtual string SysUserAccountId { get; set; }
        ///<summary>
        /// IP, varchar
        ///</summary>
        public virtual string Ip { get; set; }
     
    }
}

