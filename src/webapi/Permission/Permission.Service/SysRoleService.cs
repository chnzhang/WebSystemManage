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
    /// Table, sys_role
    ///</summary>
    public class SysRoleService
    {
        public ISysRoleRepository SysRoleRepository { get; }

        public SysRoleService(ISysRoleRepository sysRoleRepository)
        {
            SysRoleRepository = sysRoleRepository;
        }

        public int Insert(SysRole sysRole)
        {
            return SysRoleRepository.Insert(sysRole);
        }

        public int DeleteById(string id)
        {
            return SysRoleRepository.DeleteById(id);
        }

        public int Update(SysRole sysRole)
        {
            return SysRoleRepository.Update(sysRole);
        }

    }
}

