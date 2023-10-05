using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnviarCorreo.Startup))]
namespace EnviarCorreo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
