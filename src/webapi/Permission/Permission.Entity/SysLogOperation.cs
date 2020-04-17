//*******************************
// Create By cnzhang
// Date 2020-04-17 12:05
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
using Common;

namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_log_operation
    ///</summary>
    public class SysLogOperation:BaseEntity
    {
     
        ///<summary>
        /// SYS_USER_ACCOUNT_ID, varchar
        ///</summary>
        public virtual string SysUserAccountId { get; set; }
        ///<summary>
        /// OPERATION, varchar
        ///</summary>
        public virtual string Operation { get; set; }
        ///<summary>
        /// METHOD, varchar
        ///</summary>
        public virtual string Method { get; set; }
        ///<summary>
        /// PARAMS, varchar
        ///</summary>
        public virtual string Params { get; set; }
        ///<summary>
        /// TIME, int
        ///</summary>
        public virtual int? Time { get; set; }
        ///<summary>
        /// IP, varchar
        ///</summary>
        public virtual string Ip { get; set; }
       
    }
}

