using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentiyApp.Startup))]
namespace IdentiyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
