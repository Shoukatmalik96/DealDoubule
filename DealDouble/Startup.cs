using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealDouble.Startup))]
namespace DealDouble
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
