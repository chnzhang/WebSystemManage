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
    /// Table, sys_file
    ///</summary>
    public class SysFileService
    {
        public ISysFileRepository SysFileRepository { get; }

        public SysFileService(ISysFileRepository sysFileRepository)
        {
            SysFileRepository = sysFileRepository;
        }

        public int Insert(SysFile sysFile)
        {
            return SysFileRepository.Insert(sysFile);
        }

        public int DeleteById(string id)
        {
            return SysFileRepository.DeleteById(id);
        }

        public int Update(SysFile sysFile)
        {
            return SysFileRepository.Update(sysFile);
        }

    }
}

