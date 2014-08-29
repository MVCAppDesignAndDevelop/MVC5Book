using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ch4.Startup))]
namespace ch4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
