using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS.Startup))]
namespace CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
