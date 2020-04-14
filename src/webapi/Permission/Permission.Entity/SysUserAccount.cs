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
    /// Table, sys_user_account
    ///</summary>
    public class SysUserAccount:BaseEntity
    {
      
        ///<summary>
        /// LOGIN_ACCOUNT, varchar
        ///</summary>
        public virtual string LoginAccount { get; set; }
        ///<summary>
        /// PASSWORD, varchar
        ///</summary>
        public virtual string Password { get; set; }
        ///<summary>
        /// SALT, varchar
        ///</summary>
        public virtual string Salt { get; set; }
      
        ///<summary>
        /// UPDATE_TIME, datetime
        ///</summary>
        public virtual DateTime UpdateTime { get; set; }
    }
}

