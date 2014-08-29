using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoleSample.Startup))]
namespace RoleSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
