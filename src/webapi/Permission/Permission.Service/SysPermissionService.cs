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
    /// Table, sys_permission
    ///</summary>
    public class SysPermissionService
    {
        public ISysPermissionRepository SysPermissionRepository { get; }

        public SysPermissionService(ISysPermissionRepository sysPermissionRepository)
        {
            SysPermissionRepository = sysPermissionRepository;
        }

        public int Insert(SysPermission sysPermission)
        {
            return SysPermissionRepository.Insert(sysPermission);
        }

        public int DeleteById(string id)
        {
            return SysPermissionRepository.DeleteById(id);
        }

        public int Update(SysPermission sysPermission)
        {
            return SysPermissionRepository.Update(sysPermission);
        }

    }
}

