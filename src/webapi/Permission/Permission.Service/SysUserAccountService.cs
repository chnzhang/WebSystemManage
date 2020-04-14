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
    public class SysUserAccountService
    {
        public ISysUserAccountRepository SysUserAccountRepository { get; }

        public SysUserAccountService(ISysUserAccountRepository sysUserAccountRepository)
        {
            SysUserAccountRepository = sysUserAccountRepository;
        }

        public int Insert(SysUserAccount sysUserAccount)
        {
            return SysUserAccountRepository.Insert(sysUserAccount);
        }

        public int DeleteById(string id)
        {
            return SysUserAccountRepository.DeleteById(id);
        }

        public int Update(SysUserAccount sysUserAccount)
        {
            return SysUserAccountRepository.Update(sysUserAccount);
        }

    }
}

