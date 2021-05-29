using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WADProject.Models;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class CustomUserService : BaseService
    {
        public CustomUserService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {
        }

        public List<CustomUser> GetUsers()
        {
            return RepositoryWrapper.CustomUserRepository.FindAll().ToList();
        }

        public List<CustomUser> GetUsersByCondition(Expression<Func<CustomUser, bool>> expression)
        {
            return RepositoryWrapper.CustomUserRepository.FindByCondition(expression).ToList();
        }

        public void AddUser(CustomUser user)
        {
            RepositoryWrapper.CustomUserRepository.Create(user);
        }

        public void UpdateUser(CustomUser user)
        {
            RepositoryWrapper.CustomUserRepository.Update(user);
        }

        public void DeleteUser(CustomUser user)
        {
            RepositoryWrapper.CustomUserRepository.Delete(user);
        }
    }
}
