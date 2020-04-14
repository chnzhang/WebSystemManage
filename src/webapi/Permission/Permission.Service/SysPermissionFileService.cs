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
    /// Table, sys_permission_file
    ///</summary>
    public class SysPermissionFileService
    {
        public ISysPermissionFileRepository SysPermissionFileRepository { get; }

        public SysPermissionFileService(ISysPermissionFileRepository sysPermissionFileRepository)
        {
            SysPermissionFileRepository = sysPermissionFileRepository;
        }

        public int Insert(SysPermissionFile sysPermissionFile)
        {
            return SysPermissionFileRepository.Insert(sysPermissionFile);
        }

        public int DeleteById(string id)
        {
            return SysPermissionFileRepository.DeleteById(id);
        }

        public int Update(SysPermissionFile sysPermissionFile)
        {
            return SysPermissionFileRepository.Update(sysPermissionFile);
        }

    }
}

