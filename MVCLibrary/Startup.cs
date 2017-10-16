using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLibrary.Startup))]
namespace MVCLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
