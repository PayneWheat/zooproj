using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zoo_Project.Startup))]
namespace Zoo_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
