using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FINAL.Startup))]
namespace FINAL
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
