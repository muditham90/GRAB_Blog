using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GBAB_Blog.Startup))]
namespace GBAB_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
