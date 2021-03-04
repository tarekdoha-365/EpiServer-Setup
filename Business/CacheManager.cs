using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.Cache;
using EpiServer_Setup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace EpiServer_Setup.Business
{
    public class CacheManager : ICacheManager
    {
        private readonly ISynchronizedObjectInstanceCache _cache;
        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository _contentTypeRepository;
        public CacheManager(IContentTypeRepository contentTypeRepository, IContentLoader contentLoader, ISynchronizedObjectInstanceCache cache)
        {
            _contentTypeRepository = contentTypeRepository;
            _contentLoader = contentLoader;
            _cache = cache;
        }
        public T Get<T>(string key)
        {
            return CastValue<T>(_cache.Get(key));
        }
        private static T CastValue<T>(object value)
        {
            if (value == null || value is DBNull)
            {
                return default(T);
            }
            var valType = value.GetType();
            if (valType.IsGenericType && valType.GetGenericTypeDefinition() == typeof(LazyObject<>))
            {
                return CastValue<T>(valType.GetProperty("Value").GetValue(value));
            }
            if (value is T)
            {
                return (T)value;
            }
            var t = typeof(T);
            t = (Nullable.GetUnderlyingType(t) ?? t);
            if (typeof(IConvertible).IsAssignableFrom(t) && typeof(IConvertible).IsAssignableFrom(value.GetType()))
            {
                return (T)Convert.ChangeType(value, t);
            }
            return default(T);
        }
        private class LazyObject<T> : Lazy<T>
        {
            public LazyObject(Func<T> valueFactory) : base(valueFactory) { }
            public LazyObject(Func<T> valueFactory, LazyThreadSafetyMode mode) : base(valueFactory, mode) { }
        }
        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes, IEnumerable<ContentReference> roots)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object value, TimeSpan timespan, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object value, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public void OnContentChange(object sender, ContentEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Remove(string cacheKey)
        {
            throw new NotImplementedException();
        }
    }
}