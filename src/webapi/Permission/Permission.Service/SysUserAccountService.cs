//*******************************
// Create By cnzhang
// Date 2020-04-14 15:32
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using System;
using System.Linq;
using Permission.Entity;
using Permission.Repository;

namespace Permission.Service
{
    ///<summary>
    /// Table, sys_user_account
    ///</summary>
    public class SysUserAccountService : BaseService<ISysUserAccountRepository, SysUserAccount>
    {
        public ISysUserAccountRepository SysUserAccountRepository { get; }

        public SysUserAccountService(ISysUserAccountRepository sysUserAccountRepository) : base(sysUserAccountRepository)
        {
            SysUserAccountRepository = sysUserAccountRepository;
        }

    }
}

