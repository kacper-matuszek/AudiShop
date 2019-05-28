using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AudiShop.Helpers
{
    public static class UrlHelpers
    {
        public static string PathOfModel(this UrlHelper param, string modelName)
        {
            var _modelIcons = AppConfig.ModelIcons;
            var _path = Path.Combine(_modelIcons, modelName);
            var _absolutePath = param.Content(string.Format("{0}.jpg",_path));

            return _absolutePath;
        }
    }
}