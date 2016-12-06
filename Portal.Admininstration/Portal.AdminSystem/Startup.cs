using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portal.AdminSystem.Startup))]
namespace Portal.AdminSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
