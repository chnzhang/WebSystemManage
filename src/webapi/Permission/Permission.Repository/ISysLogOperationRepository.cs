//*******************************
// Create By cnzhang
// Date 2020-04-17 12:05
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SmartSql.DyRepository;
using SmartSql.DyRepository.Annotations;
using Permission.Entity;

namespace Permission.Repository
{
    ///<summary>
    /// Table, sys_log_operation
    ///</summary>
    public interface ISysLogOperationRepository : IRepository<SysLogOperation, string>
        , IRepositoryAsync<SysLogOperation, string>
    {

    }
}

