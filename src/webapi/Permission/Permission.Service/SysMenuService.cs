//*******************************
// Create By cnzhang
// Date 2020-03-19 18:53
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
    /// Table, sys_menu
    ///</summary>
    public class SysMenuService
    {
        public ISysMenuRepository SysMenuRepository { get; }

        public SysMenuService(ISysMenuRepository sysMenuRepository)
        {
            SysMenuRepository = sysMenuRepository;
        }

        public int Insert(SysMenu sysMenu)
        {
            return SysMenuRepository.Insert(sysMenu);
        }

        public int DeleteById(string id)
        {
            return SysMenuRepository.DeleteById(id);
        }

        public int Update(SysMenu sysMenu)
        {
            return SysMenuRepository.Update(sysMenu);
        }

    }
}

