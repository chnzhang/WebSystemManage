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
    /// Table, sys_permission_menu
    ///</summary>
    public class SysPermissionMenuService
    {
        public ISysPermissionMenuRepository SysPermissionMenuRepository { get; }

        public SysPermissionMenuService(ISysPermissionMenuRepository sysPermissionMenuRepository)
        {
            SysPermissionMenuRepository = sysPermissionMenuRepository;
        }

        public int Insert(SysPermissionMenu sysPermissionMenu)
        {
            return SysPermissionMenuRepository.Insert(sysPermissionMenu);
        }

        public int DeleteById(string id)
        {
            return SysPermissionMenuRepository.DeleteById(id);
        }

        public int Update(SysPermissionMenu sysPermissionMenu)
        {
            return SysPermissionMenuRepository.Update(sysPermissionMenu);
        }

    }
}

