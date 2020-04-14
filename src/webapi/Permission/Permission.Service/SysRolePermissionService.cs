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
    /// Table, sys_role_permission
    ///</summary>
    public class SysRolePermissionService
    {
        public ISysRolePermissionRepository SysRolePermissionRepository { get; }

        public SysRolePermissionService(ISysRolePermissionRepository sysRolePermissionRepository)
        {
            SysRolePermissionRepository = sysRolePermissionRepository;
        }

        public int Insert(SysRolePermission sysRolePermission)
        {
            return SysRolePermissionRepository.Insert(sysRolePermission);
        }

        public int DeleteById(string id)
        {
            return SysRolePermissionRepository.DeleteById(id);
        }

        public int Update(SysRolePermission sysRolePermission)
        {
            return SysRolePermissionRepository.Update(sysRolePermission);
        }

    }
}

