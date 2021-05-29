using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class StaffService : BaseService
    {
        public StaffService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Staff> GetStaff()
        {
            return RepositoryWrapper.StaffRepository.FindAll().ToList();
        }

        public List<Staff> GetStaffByCondition(Expression<Func<Staff, bool>> expression)
        {
            return RepositoryWrapper.StaffRepository.FindByCondition(expression).ToList();
        }

        public void AddStaff(Staff staff)
        {
            RepositoryWrapper.StaffRepository.Create(staff);
        }

        public void UpdateStaff(Staff staff)
        {
            RepositoryWrapper.StaffRepository.Update(staff);
        }

        public void DeleteStaff(Staff staff)
        {
            RepositoryWrapper.StaffRepository.Delete(staff);
        }
    }
}
