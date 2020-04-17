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
        [NetRequired(MessageKey = "uservalidate:password.empty", Groups = new[] { typeof(BaseModelType.Insert) })]
        [NetStringLength(15, MinimumLength = 6, MessageKey = "uservalidate:password.length", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual string Password { get; set; }



        [NetCompare("Password", MessageKey = "uservalidate:password.rep", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual string RePassword { get; set; }


        // [NetRange(1, 3, ErrorMessage = "状态参数值错误", Groups = new[] { typeof(BaseModelType.Insert) })]
        public virtual int? Status { get; set; }

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

