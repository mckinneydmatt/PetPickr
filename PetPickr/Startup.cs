using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetPickr.Startup))]
namespace PetPickr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
