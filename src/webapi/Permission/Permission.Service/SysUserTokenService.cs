//*******************************
// Create By cnzhang
// Date 2020-04-14 15:33
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
    /// Table, sys_user_token
    ///</summary>
    public class SysUserTokenService:BaseService<ISysUserTokenRepository,SysUserToken>
    {
        public ISysUserTokenRepository SysUserTokenRepository { get; }

        public SysUserTokenService(ISysUserTokenRepository sysUserTokenRepository):base(sysUserTokenRepository)
        {
            SysUserTokenRepository = sysUserTokenRepository;
        }

    }
}

