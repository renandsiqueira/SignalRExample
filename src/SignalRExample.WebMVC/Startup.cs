using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRExample.WebMVC.Startup))]
namespace SignalRExample.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
