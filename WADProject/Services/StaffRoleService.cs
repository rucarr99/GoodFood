using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class StaffRoleService : BaseService
    {
        public StaffRoleService(IRepositoryWrapper repositoryWrapper) 
            : base(repositoryWrapper)
        {
        }

        public List<StaffRole> GetStaffRoles()
        {
            return RepositoryWrapper.StaffRoleRepository.FindAll().ToList();
        }

        public List<StaffRole> GetStaffRolesByCondition(Expression<Func<StaffRole, bool>> expression)
        {
            return RepositoryWrapper.StaffRoleRepository.FindByCondition(expression).ToList();
        }

        public void AddStaffRole(StaffRole staffRole)
        {
            RepositoryWrapper.StaffRoleRepository.Create(staffRole);
        }

        public void UpdateStaffRole(StaffRole staffRole)
        {

            RepositoryWrapper.StaffRoleRepository.Update(staffRole);
        }

        public void DeleteStaffRole(StaffRole staffRole)
        {
            RepositoryWrapper.StaffRoleRepository.Delete(staffRole);
        }
    }
}
