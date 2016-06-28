using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quiz1.Startup))]
namespace Quiz1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
