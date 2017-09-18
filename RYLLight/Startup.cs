using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RYLLight.Startup))]
namespace RYLLight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
