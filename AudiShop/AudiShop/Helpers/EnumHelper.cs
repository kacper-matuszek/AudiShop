using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudiShop.Helpers
{
    public static class EnumHelper
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}