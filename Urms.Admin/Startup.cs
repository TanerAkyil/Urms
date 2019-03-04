using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Urms.Admin.Startup))]
namespace Urms.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
