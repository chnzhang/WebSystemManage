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
    /// Table, sys_user_role
    ///</summary>
    public class SysUserRoleService
    {
        public ISysUserRoleRepository SysUserRoleRepository { get; }

        public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository)
        {
            SysUserRoleRepository = sysUserRoleRepository;
        }

        public int Insert(SysUserRole sysUserRole)
        {
            return SysUserRoleRepository.Insert(sysUserRole);
        }

        public int DeleteById(string id)
        {
            return SysUserRoleRepository.DeleteById(id);
        }

        public int Update(SysUserRole sysUserRole)
        {
            return SysUserRoleRepository.Update(sysUserRole);
        }

    }
}

