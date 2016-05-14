using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Foundation_initiatives.Startup))]
namespace Foundation_initiatives
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
