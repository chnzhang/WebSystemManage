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
    /// Table, sys_group
    ///</summary>
    public class SysGroupService
    {
        public ISysGroupRepository SysGroupRepository { get; }

        public SysGroupService(ISysGroupRepository sysGroupRepository)
        {
            SysGroupRepository = sysGroupRepository;
        }

        public int Insert(SysGroup sysGroup)
        {
            return SysGroupRepository.Insert(sysGroup);
        }

        public int DeleteById(string id)
        {
            return SysGroupRepository.DeleteById(id);
        }

        public int Update(SysGroup sysGroup)
        {
            return SysGroupRepository.Update(sysGroup);
        }

    }
}

