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
    /// Table, sys_organization
    ///</summary>
    public class SysOrganizationService
    {
        public ISysOrganizationRepository SysOrganizationRepository { get; }

        public SysOrganizationService(ISysOrganizationRepository sysOrganizationRepository)
        {
            SysOrganizationRepository = sysOrganizationRepository;
        }

        public int Insert(SysOrganization sysOrganization)
        {
            return SysOrganizationRepository.Insert(sysOrganization);
        }

        public int DeleteById(string id)
        {
            return SysOrganizationRepository.DeleteById(id);
        }

        public int Update(SysOrganization sysOrganization)
        {
            return SysOrganizationRepository.Update(sysOrganization);
        }

    }
}

