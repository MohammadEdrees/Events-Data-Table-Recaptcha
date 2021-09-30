using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventdotNetFrameWork.Startup))]
namespace EventdotNetFrameWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
