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
    /// Table, sys_user_group
    ///</summary>
    public class SysUserGroupService
    {
        public ISysUserGroupRepository SysUserGroupRepository { get; }

        public SysUserGroupService(ISysUserGroupRepository sysUserGroupRepository)
        {
            SysUserGroupRepository = sysUserGroupRepository;
        }

        public int Insert(SysUserGroup sysUserGroup)
        {
            return SysUserGroupRepository.Insert(sysUserGroup);
        }

        public int DeleteById(string id)
        {
            return SysUserGroupRepository.DeleteById(id);
        }

        public int Update(SysUserGroup sysUserGroup)
        {
            return SysUserGroupRepository.Update(sysUserGroup);
        }

    }
}

