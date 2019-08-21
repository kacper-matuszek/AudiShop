using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace AudiShop.Helpers
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private Cache _cache => HttpContext.Current.Cache;
        public object Get(string key)
        {
            return _cache[key];
        }

        public bool IsSet(string key)
        {
            return _cache[key] != null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
            var expirationTime = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

            _cache.Insert(key, data, null, expirationTime, Cache.NoSlidingExpiration);
        }
    }
}