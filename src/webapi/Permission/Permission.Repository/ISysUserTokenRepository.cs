//*******************************
// Create By cnzhang
// Date 2020-04-14 15:33
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
    /// Table, sys_user_token
    ///</summary>
    public interface ISysUserTokenRepository : IRepository<SysUserToken, string>
        , IRepositoryAsync<SysUserToken, string>
    {

    }
}

