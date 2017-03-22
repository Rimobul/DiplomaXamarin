using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PushServer.Startup))]

namespace PushServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}