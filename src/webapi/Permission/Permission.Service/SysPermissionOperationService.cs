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
    /// Table, sys_permission_operation
    ///</summary>
    public class SysPermissionOperationService
    {
        public ISysPermissionOperationRepository SysPermissionOperationRepository { get; }

        public SysPermissionOperationService(ISysPermissionOperationRepository sysPermissionOperationRepository)
        {
            SysPermissionOperationRepository = sysPermissionOperationRepository;
        }

        public int Insert(SysPermissionOperation sysPermissionOperation)
        {
            return SysPermissionOperationRepository.Insert(sysPermissionOperation);
        }

        public int DeleteById(string id)
        {
            return SysPermissionOperationRepository.DeleteById(id);
        }

        public int Update(SysPermissionOperation sysPermissionOperation)
        {
            return SysPermissionOperationRepository.Update(sysPermissionOperation);
        }

    }
}

