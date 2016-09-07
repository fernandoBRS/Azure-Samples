using System;
using System.Threading.Tasks;
using Microsoft.ApplicationServer.Caching;

namespace CloudDesignPatterns.CacheAsidePattern
{
    public class CacheAside
    {
        private static DataCache cache;

        public CacheAside()
        {
            cache = new DataCacheFactory().GetCache("cache-name");   
        }

        private MyEntity GetMyEntity(int id)
        {
            // Define a unique key for this method and its parameters.
            var key = $"StoreWithCache_GetAsync_{id}";
            var expiration = TimeSpan.FromMinutes(3);
            var cacheException = false;

            try
            {
                // Try to get the entity from the cache.
                var cacheItem = cache.GetCacheItem(key);

                if (cacheItem != null)
                {
                    return cacheItem.Value as MyEntity;
                }
            }
            catch (DataCacheException)
            {
                // If there is a cache related issue, raise an exception 
                // and avoid using the cache for the rest of the call.
                cacheException = true;
            }

            // If there is a cache miss, get the entity from the original store and cache it.
            var entity = new MyEntity
            {
                Id = 1,
                Name = "Fernando"
            };

            if (!cacheException)
            {
                try
                {
                    // Avoid caching a null value.
                    if (!string.IsNullOrEmpty(entity.Name))
                    {
                        // Put the item in the cache with a custom expiration time that 
                        // depends on how critical it might be to have stale data.
                        cache.Put(key, entity, expiration);
                    }
                }
                catch (DataCacheException)
                {
                    // If there is a cache related issue, ignore it
                    // and just return the entity.
                }
            }

            return entity;
        }

        public async Task UpdateEntityAsync(MyEntity entity)
        {
            // TODO: Update the object in the original data store
            //await store.UpdateEntityAsync(entity).ConfigureAwait(false);

            // Get the correct key for the cached object.
            var key = GetAsyncCacheKey(entity.Id);
            
            // Then, invalidate the current cache object
            cache.Remove(key);
        }

        private static string GetAsyncCacheKey(int objectId)
        {
            return $"StoreWithCache_GetAsync_{objectId}";
        }
    }
}
