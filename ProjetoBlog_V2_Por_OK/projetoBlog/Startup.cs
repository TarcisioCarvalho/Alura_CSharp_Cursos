using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoBlog.Startup))]
namespace ProjetoBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
