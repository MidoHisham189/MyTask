using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tekegy_SendSms_Task.Startup))]
namespace Tekegy_SendSms_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
