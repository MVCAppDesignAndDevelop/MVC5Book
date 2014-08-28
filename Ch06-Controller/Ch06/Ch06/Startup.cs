using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ch06.Startup))]
namespace Ch06
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
