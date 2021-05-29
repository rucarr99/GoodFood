using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WADProject.Repositories;

namespace WADProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
#pragma warning disable 618
        private readonly IHostingEnvironment _hostingEnvironment;
#pragma warning restore 618
        public UnitOfWork(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }
        public async void UploadImage(IFormFile file)
        {
            var filename = file.FileName.Trim('"');
            filename = EnsureFileName(filename);
            var buffer = new byte[16 * 1024];
            await using var output = File.Create(GetPathAndFileName(filename));
            await using var input = file.OpenReadStream();
            int readBytes;
            while ((readBytes = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await output.WriteAsync(buffer, 0, readBytes);
            }
        }

        private string GetPathAndFileName(string filename)
        {
            var path = _hostingEnvironment.WebRootPath + "/uploads/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path + filename;
        }

        private string EnsureFileName(string filename)
        {
            if (filename.Contains("/"))
                filename = filename[(filename.IndexOf("/", StringComparison.Ordinal) + 1)..];
            return filename;
        }
    }
}
