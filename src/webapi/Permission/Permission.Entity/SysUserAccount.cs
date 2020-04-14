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
    /// Table, sys_user_account
    ///</summary>
    public class SysUserAccount
    {
        ///<summary>
        /// ID, varchar
        ///</summary>
        public virtual string Id { get; set; }
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
        /// CREATE_TIME, datetime
        ///</summary>
        public virtual DateTime CreateTime { get; set; }
        ///<summary>
        /// UPDATE_TIME, datetime
        ///</summary>
        public virtual DateTime UpdateTime { get; set; }
    }
}

