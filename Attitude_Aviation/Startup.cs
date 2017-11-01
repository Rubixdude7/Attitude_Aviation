using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Attitude_Aviation.Startup))]
namespace Attitude_Aviation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
