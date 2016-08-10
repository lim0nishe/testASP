using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testASP.Startup))]
namespace testASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
