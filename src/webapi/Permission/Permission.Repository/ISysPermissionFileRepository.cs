//*******************************
// Create By cnzhang
// Date 2020-04-14 10:18
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
    /// Table, sys_permission_file
    ///</summary>
    public interface ISysPermissionFileRepository : IRepository<SysPermissionFile, string>
        , IRepositoryAsync<SysPermissionFile, string>
    {

    }
}

