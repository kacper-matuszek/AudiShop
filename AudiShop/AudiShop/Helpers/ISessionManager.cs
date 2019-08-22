using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiShop.Helpers
{
    public interface ISessionManager
    {
        T Get<T>(string key);
        void Set<T>(string name, T value);
        void Remove();
        T TryGet<T>(string key);
    }
}
