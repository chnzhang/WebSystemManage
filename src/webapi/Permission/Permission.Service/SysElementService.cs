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
    /// Table, sys_element
    ///</summary>
    public class SysElementService
    {
        public ISysElementRepository SysElementRepository { get; }

        public SysElementService(ISysElementRepository sysElementRepository)
        {
            SysElementRepository = sysElementRepository;
        }

        public int Insert(SysElement sysElement)
        {
            return SysElementRepository.Insert(sysElement);
        }

        public int DeleteById(string id)
        {
            return SysElementRepository.DeleteById(id);
        }

        public int Update(SysElement sysElement)
        {
            return SysElementRepository.Update(sysElement);
        }

    }
}

