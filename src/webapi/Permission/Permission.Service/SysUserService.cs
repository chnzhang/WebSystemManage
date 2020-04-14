//*******************************
// Create By cnzhang
// Date 2020-04-14 10:18
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
    /// Table, sys_user
    ///</summary>
    public class SysUserService
    {
        public ISysUserRepository SysUserRepository { get; }

        public SysUserService(ISysUserRepository sysUserRepository)
        {
            SysUserRepository = sysUserRepository;
        }

        public int Insert(SysUser sysUser)
        {
            return SysUserRepository.Insert(sysUser);
        }

        public int DeleteById(string id)
        {
            return SysUserRepository.DeleteById(id);
        }

        public int Update(SysUser sysUser)
        {
            return SysUserRepository.Update(sysUser);
        }

    }
}

