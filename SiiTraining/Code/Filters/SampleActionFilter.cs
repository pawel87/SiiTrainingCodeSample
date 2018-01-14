using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SiiTraining.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class SampleActionFilterImpl : ActionFilterAttribute
    {
        private readonly IRepository repository;
        private string text;
        private readonly SomeOptions options;

        public SampleActionFilterImpl(IRepository repository, string text, SomeOptions options)
        {
            this.repository = repository;
            this.text = text;
            this.options = options;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var data = repository.GetAllProducts();
            Console.WriteLine($"Hello {text}");
        }
    }

    public class SampleActionFilterAttribute: Attribute, IFilterFactory
    {
        private string text;

        // Indicates if the filter created can be reused accross requests.
        public bool IsReusable => false;

        public SampleActionFilterAttribute(string text)
        {
            this.text = text;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new SampleActionFilterImpl(
                serviceProvider.GetRequiredService<IRepository>(),
                text,
                new SomeOptions { Value = 12345 });
        }

    }

    public class SomeOptions
    {
        public int Value { get; set; }
    }


}
