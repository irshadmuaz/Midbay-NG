using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Midbay_NG.Startup))]
namespace Midbay_NG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
