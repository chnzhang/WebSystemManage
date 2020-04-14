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
    /// Table, sys_permission_element
    ///</summary>
    public class SysPermissionElementService
    {
        public ISysPermissionElementRepository SysPermissionElementRepository { get; }

        public SysPermissionElementService(ISysPermissionElementRepository sysPermissionElementRepository)
        {
            SysPermissionElementRepository = sysPermissionElementRepository;
        }

        public int Insert(SysPermissionElement sysPermissionElement)
        {
            return SysPermissionElementRepository.Insert(sysPermissionElement);
        }

        public int DeleteById(string id)
        {
            return SysPermissionElementRepository.DeleteById(id);
        }

        public int Update(SysPermissionElement sysPermissionElement)
        {
            return SysPermissionElementRepository.Update(sysPermissionElement);
        }

    }
}

