//*******************************
// Create By cnzhang
// Date 2020-04-17 12:05
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
    /// Table, sys_log_operation
    ///</summary>
    public class SysLogOperationService: BaseService<ISysLogOperationRepository,SysLogOperation>
    {
        public ISysLogOperationRepository SysLogOperationRepository { get; }

        public SysLogOperationService(ISysLogOperationRepository sysLogOperationRepository):base(sysLogOperationRepository)
        {
            SysLogOperationRepository = sysLogOperationRepository;
        }


    }
}

