//*******************************
// Create By cnzhang
// Date 2020-04-14 15:30
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
using Common;
using System.ComponentModel.DataAnnotations;

namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_user_account
    ///</summary>
    public class SysUserAccount : BaseEntity
    {

        ///<summary>
        /// LOGIN_ACCOUNT, varchar
        ///</summary>
        [Required(ErrorMessage = "验证码不能为空")]
        public virtual string LoginAccount { get; set; }
        ///<summary>
        /// PASSWORD, varchar
        ///</summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码最小长度为6")]
        [MaxLength(15, ErrorMessage = "密码最大长度为15")]
        public virtual string Password { get; set; }
        ///<summary>
        /// SALT, varchar
        ///</summary>
        public virtual string Salt { get; set; }

        ///<summary>
        /// UPDATE_TIME, datetime
        ///</summary>
        public virtual DateTime? UpdateTime { get; set; }
    }
}

