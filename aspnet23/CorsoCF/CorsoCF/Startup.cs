using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CorsoCF.Startup))]
namespace CorsoCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
