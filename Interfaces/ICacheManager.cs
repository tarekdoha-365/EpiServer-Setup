using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiServer_Setup.Interfaces
{
    public interface ICacheManager
    {
        CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes);
        CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes, IEnumerable<ContentReference> roots);
        void Remove(string cacheKey);
        void OnContentChange(object sender, ContentEventArgs e);
        T Get<T>(string key);
        void Insert(string key, object value, TimeSpan timespan, IEnumerable<Type> dependentTypes);
        void Insert(string key, object value, IEnumerable<Type> dependentTypes);
    }
}
