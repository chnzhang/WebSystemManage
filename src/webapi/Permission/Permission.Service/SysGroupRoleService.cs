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
    /// Table, sys_group_role
    ///</summary>
    public class SysGroupRoleService
    {
        public ISysGroupRoleRepository SysGroupRoleRepository { get; }

        public SysGroupRoleService(ISysGroupRoleRepository sysGroupRoleRepository)
        {
            SysGroupRoleRepository = sysGroupRoleRepository;
        }

        public int Insert(SysGroupRole sysGroupRole)
        {
            return SysGroupRoleRepository.Insert(sysGroupRole);
        }

        public int DeleteById(string id)
        {
            return SysGroupRoleRepository.DeleteById(id);
        }

        public int Update(SysGroupRole sysGroupRole)
        {
            return SysGroupRoleRepository.Update(sysGroupRole);
        }

    }
}

