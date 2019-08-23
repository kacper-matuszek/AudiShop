using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AudiShop.App_Start;

namespace AudiShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        
    }
}