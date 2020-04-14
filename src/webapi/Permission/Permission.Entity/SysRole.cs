//*******************************
// Create By cnzhang
// Date 2020-04-14 10:18
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_role
    ///</summary>
    public class SysRole
    {
        ///<summary>
        /// ID, varchar
        ///</summary>
        public virtual string Id { get; set; }
        ///<summary>
        /// NAME, varchar
        ///</summary>
        public virtual string Name { get; set; }
        ///<summary>
        /// REMARK, nchar
        ///</summary>
        public virtual string Remark { get; set; }
        ///<summary>
        /// CREATE_USER_ID, nchar
        ///</summary>
        public virtual string CreateUserId { get; set; }
        ///<summary>
        /// CREATE_USER_ORG_NO, nchar
        ///</summary>
        public virtual string CreateUserOrgNo { get; set; }
        ///<summary>
        /// CREATE_TIME, datetime
        ///</summary>
        public virtual DateTime CreateTime { get; set; }
    }
}

