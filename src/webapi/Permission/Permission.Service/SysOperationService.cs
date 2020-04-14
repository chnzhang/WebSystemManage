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
    /// Table, sys_operation
    ///</summary>
    public class SysOperationService
    {
        public ISysOperationRepository SysOperationRepository { get; }

        public SysOperationService(ISysOperationRepository sysOperationRepository)
        {
            SysOperationRepository = sysOperationRepository;
        }

        public int Insert(SysOperation sysOperation)
        {
            return SysOperationRepository.Insert(sysOperation);
        }

        public int DeleteById(string id)
        {
            return SysOperationRepository.DeleteById(id);
        }

        public int Update(SysOperation sysOperation)
        {
            return SysOperationRepository.Update(sysOperation);
        }

    }
}

