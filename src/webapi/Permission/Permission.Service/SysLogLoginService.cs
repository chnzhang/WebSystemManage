//*******************************
// Create By cnzhang
// Date 2020-04-17 11:59
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
    /// Table, sys_log_login
    ///</summary>
    public class SysLogLoginService: BaseService<ISysLogLoginRepository, SysLogLogin>
    {
        public ISysLogLoginRepository SysLogLoginRepository { get; }

        public SysLogLoginService(ISysLogLoginRepository sysLogLoginRepository):base(sysLogLoginRepository)
        {
            SysLogLoginRepository = sysLogLoginRepository;
        }

    }
}

