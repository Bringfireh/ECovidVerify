using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECovidVerify.Startup))]
namespace ECovidVerify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
