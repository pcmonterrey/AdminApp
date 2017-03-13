using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminRoku.Startup))]
namespace AdminRoku
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
