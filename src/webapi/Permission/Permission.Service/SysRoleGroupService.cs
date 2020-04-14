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
    /// Table, sys_role_group
    ///</summary>
    public class SysRoleGroupService
    {
        public ISysRoleGroupRepository SysRoleGroupRepository { get; }

        public SysRoleGroupService(ISysRoleGroupRepository sysRoleGroupRepository)
        {
            SysRoleGroupRepository = sysRoleGroupRepository;
        }

        public int Insert(SysRoleGroup sysRoleGroup)
        {
            return SysRoleGroupRepository.Insert(sysRoleGroup);
        }

        public int DeleteById(string id)
        {
            return SysRoleGroupRepository.DeleteById(id);
        }

        public int Update(SysRoleGroup sysRoleGroup)
        {
            return SysRoleGroupRepository.Update(sysRoleGroup);
        }

    }
}

