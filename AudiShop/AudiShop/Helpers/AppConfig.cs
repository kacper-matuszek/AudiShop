using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AudiShop.Helpers
{
    public class AppConfig
    {
        private static readonly string _modelIcons = ConfigurationManager.AppSettings["ModelIcons"];

        public static string ModelIcons => _modelIcons;
    }
}