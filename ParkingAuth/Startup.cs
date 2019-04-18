using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkingAuth.Startup))]
namespace ParkingAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
