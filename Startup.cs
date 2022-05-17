using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistroHorasPage.Startup))]
namespace RegistroHorasPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
