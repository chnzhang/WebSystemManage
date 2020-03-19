//*******************************
// Create By cnzhang
// Date 2020-03-19 18:53
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
    /// Table, sys_menu
    ///</summary>
    public interface ISysMenuRepository : IRepository<SysMenu, string>
        , IRepositoryAsync<SysMenu, string>
    {

        [Statement(Id = "GetEntity")]
        new SysMenu GetById([Param("MenuId")]string id);
        [Statement(Id = "GetEntity")]
        new Task<SysMenu> GetByIdAsync([Param("MenuId")]string id);
        [Statement(Id = "Delete")]
        new int DeleteById([Param("MenuId")]string id);
        [Statement(Id = "Delete")]
        new Task<int> DeleteByIdAsync([Param("MenuId")]string id);
    }
}

