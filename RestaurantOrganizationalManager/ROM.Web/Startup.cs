using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ROM.Web.Startup))]
namespace ROM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
