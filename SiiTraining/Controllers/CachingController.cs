using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using Microsoft.Extensions.Primitives;
using SiiTraining.Code.Services;
using SiiTraining.Code.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiiTraining.Models.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System;

namespace SiiTraining.Controllers
{
    public class CachingController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly IRepository repository;

        private readonly IDistributedCache distributedCache;

        public CachingController(IMemoryCache memoryCache, IRepository repository)
        {
            this.memoryCache = memoryCache;
            this.repository = repository;
        }

        //public CachingController(IDistributedCache distributedCache, IRepository repository)
        //{
        //    this.distributedCache = distributedCache;
        //    this.repository = repository;
        //}

        public IActionResult Index()
        {
            memoryCache.Set("key", "test",
            new MemoryCacheEntryOptions()
                .RegisterPostEvictionCallback((key, value, reason, state) => {  /*Do Something Here */ })
            );

            var cts = new CancellationTokenSource();
            memoryCache.Set("key", "test",
                new MemoryCacheEntryOptions()
                    .AddExpirationToken(new CancellationChangeToken(cts.Token))
             );

            return View();
        }

        public IActionResult AddToCache()
        {
            var value = DateTime.Now;
            memoryCache.Set("currentDate", value, new MemoryCacheEntryOptions().RegisterPostEvictionCallback(MyCallback, this));

            return View("Message", "xxx");
        }

        public IActionResult RemoveFromCache()
        {
            memoryCache.Remove("currentDate");

            return View("Message", "Removed");
        }


        private static void MyCallback(object key, object value, EvictionReason reason, object state)
        {



        }


        public CacheSampleResponse SomeExample()
        {
            var requestKey = "ABC";
            List<Product> products = null;
            if(!memoryCache.TryGetValue(requestKey, out products))
            {
                products = repository.GetAllProducts();
                memoryCache.Set(requestKey, products);
            }

            var response = new CacheSampleResponse()
            {
                ItemsCount = products != null ? products.Count : 0
            };

            return response;
        }

        public IActionResult DistributedSample()
        {
            var fromCache = distributedCache.Get("key");
            var fromCache2 = distributedCache.GetString("key");

            var val = "some value";
            var valBytes = Encoding.ASCII.GetBytes(val);
            distributedCache.Set("otherkey", valBytes, new DistributedCacheEntryOptions()
            {
                 AbsoluteExpiration = DateTime.Now.AddHours(3)
            });

            return View();
        }

        [ResponseCache(Duration = 30)]
        public IActionResult FullPageCache()
        {
            var dateTime = DateTime.Now;

            return View("Message", $"Page rendered at: {dateTime}");
        }

        [ResponseCache(Duration = 30, VaryByQueryKeys = new[] { "lang" })]
        public IActionResult FullPageCache2()
        {
            var dateTime = DateTime.Now;

            return View("Message", $"Page rendered at: {dateTime}");
        }
    }
}