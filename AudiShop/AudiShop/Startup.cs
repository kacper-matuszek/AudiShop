using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AudiShop.App_Start;
using Hangfire;

namespace AudiShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration
                  .UseSqlServerStorage("AudiContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }

        
    }
}