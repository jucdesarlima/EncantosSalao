using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EncantosSalao.Web.Areas.Identity.IdentityHostingStartup))]
namespace EncantosSalao.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
