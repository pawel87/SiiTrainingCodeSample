using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SiiTraining.Code.Filters
{
    public class FilterWithOrderAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //To do : before the action executes  
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //To do : after the action executes  
        }
    }

}
