using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(卧龙管理网站.Startup))]
namespace 卧龙管理网站
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
