using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface ICacheService
    { 
        T Get<T>(string name);
        T Add<T>(string name, T data);
        void Clear(string name);
    }

    public class CacheService
        : ICacheService
    {
        private IMemoryCache MemoryCache { get; set; }
        public CacheService(IMemoryCache MemoryCache)
        {
            this.MemoryCache = MemoryCache;
        }

        public T Add<T>(string name, T data)
        {
            T cached;
            if (!MemoryCache.TryGetValue<T>(name, out cached))
            {
                cached = data;

                var opt = new MemoryCacheEntryOptions();
                opt.SlidingExpiration = TimeSpan.FromHours(12);

                MemoryCache.Set(name, cached, opt);
            }

            return cached;
        }

        public void Clear(string name)
        {
            MemoryCache.Remove(name);
        }

        public T Get<T>(string name)
        {
            T cached;
            MemoryCache.TryGetValue<T>(name, out cached);
            return cached;
        }
    }
}
