using Microsoft.Extensions.Caching.Memory;
using System;

namespace Tranzact.Dominio.Contract.Repository
{
    public class MemoryCache : IMemoryCache
    {
        private readonly Microsoft.Extensions.Caching.Memory.IMemoryCache _cache;

        public MemoryCache(Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public bool TryGetValue<TValorCache>(string clave, out TValorCache valor)
        {
            return _cache.TryGetValue(clave, out valor);
        }

        public void SetValue<TValorCache>(string clave, TValorCache valor)
        {
            //var cacheEntryOptions = new MemoryCacheEntryOptions()
            //    // Keep in cache for this time, reset time if accessed.
            //    .SetSlidingExpiration(TimeSpan.FromSeconds(3));
            //_cache.Set(clave, valor, cacheEntryOptions);

            // Save data in cache and set the relative expiration time to one day
            _cache.Set(clave, valor, TimeSpan.FromDays(1));
        }
    }
}
