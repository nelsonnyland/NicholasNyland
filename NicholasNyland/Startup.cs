using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NicholasNyland.Startup))]
namespace NicholasNyland
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
