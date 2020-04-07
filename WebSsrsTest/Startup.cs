using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSsrsTest.Startup))]
namespace WebSsrsTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
