using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentitySample.Startup))]
namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
