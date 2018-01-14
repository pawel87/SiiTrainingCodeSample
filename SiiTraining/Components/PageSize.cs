using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class PageSize : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            return View(response.Content.Headers.ContentLength);
        }
    }
}
