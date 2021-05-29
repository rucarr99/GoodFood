using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WADProject.Repositories
{
    public interface IUnitOfWork
    {
        void UploadImage(IFormFile file);
    }
}
