using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppDri.Startup))]
namespace WebAppDri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
