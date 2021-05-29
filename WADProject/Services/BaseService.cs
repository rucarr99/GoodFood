using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADProject.Repositories;

namespace WADProject.Services
{ 
    public class BaseService
    {
        protected IRepositoryWrapper RepositoryWrapper;

        public BaseService(IRepositoryWrapper iRepositoryWrapper)
        {
            RepositoryWrapper = iRepositoryWrapper;
        }

        public void Save()
        {
            RepositoryWrapper.Save();
        }
    }
}
