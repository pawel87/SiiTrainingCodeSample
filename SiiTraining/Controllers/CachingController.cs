using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using Microsoft.Extensions.Primitives;
using SiiTraining.Code.Services;
using SiiTraining.Code.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiiTraining.Models.Caching;

namespace SiiTraining.Controllers
{
    public class CachingController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly IRepository repository;

        public CachingController(IMemoryCache memoryCache, IRepository repository)
        {
            this.memoryCache = memoryCache;
            this.repository = repository;
        }

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
    }
}