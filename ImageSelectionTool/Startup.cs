using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ImageSelectionTool.Startup))]

namespace ImageSelectionTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
