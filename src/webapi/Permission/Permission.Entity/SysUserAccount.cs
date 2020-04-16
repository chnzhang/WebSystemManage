//*******************************
// Create By cnzhang
// Date 2020-04-14 15:30
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
using Common;
using System.ComponentModel.DataAnnotations;
using NetDataAnnotations;

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
        [NetRequired(MessageKey = "uservalidate:usernamempty", Groups = new[] { typeof(BaseModelType.Insert) })]      
        public virtual string LoginAccount { get; set; }

        ///<summary>
        /// PASSWORD, varchar
        ///</summary>
        [NetRequired(ErrorMessage = "密码不能为空")]
        [NetStringLength(15, MinimumLength = 6, ErrorMessage = "密码最小长度为6,最大长度为1", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual string Password { get; set; }



        [NetCompare("Password", ErrorMessage = "两次输入的密码不一致", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual string RePassword { get; set; }


        [NetRange(1, 3, ErrorMessage = "状态参数值错误", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual int Status { get; set; }

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

