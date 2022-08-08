using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesLibrary.Startup))]
namespace MoviesLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
