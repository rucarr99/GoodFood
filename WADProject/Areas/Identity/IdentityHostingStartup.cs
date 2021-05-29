using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WADProject.Areas.Identity.IdentityHostingStartup))]
namespace WADProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}