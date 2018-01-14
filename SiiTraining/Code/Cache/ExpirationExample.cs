using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SiiTraining.Code.Cache
{
    public class ExpirationExample
    {
        private readonly IMemoryCache _cache;

        public void Foo()
        {
            var item = new object();

            //absolute expiration using TimeSpan
            _cache.Set("key", item, TimeSpan.FromDays(1));

            //absolute expiration using DateTime
            _cache.Set("key", item, new DateTime(2020, 1, 1));

            //sliding expiration (evict if not accessed for 7 days)
            _cache.Set("key", item, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(7)
            });

            //use both absolute and sliding expiration
            _cache.Set("key", item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30),
                SlidingExpiration = TimeSpan.FromDays(7)
            });

            // use a cancellation token
            var tokenSource = new CancellationTokenSource();

            var token = new CancellationChangeToken(tokenSource.Token);

            _cache.Set("key", item, new MemoryCacheEntryOptions().AddExpirationToken(token));
        }

    }
}
