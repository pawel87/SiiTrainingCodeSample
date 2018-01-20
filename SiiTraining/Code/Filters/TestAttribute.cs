using Microsoft.AspNetCore.Mvc.Filters;
using SiiTraining.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class TestAttribute : ActionFilterAttribute
    {
        private IRepository repository;
        public TestAttribute(IRepository repo)
        {
            repository = repo;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
