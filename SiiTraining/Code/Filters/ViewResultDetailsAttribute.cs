using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class ViewResultDetailsAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["Result Type"] = context.Result.GetType().Name
            };

            ViewResult vr;
            if((vr = context.Result as ViewResult) != null)
            {
                dictionary["View Name"] = vr.ViewName;
                dictionary["Model Type"] = vr.ViewData.Model.GetType().Name;
                dictionary["Model Data"] = vr.ViewData.Model.ToString();
            }

            context.Result = new ViewResult()
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = dictionary
                }
            };

        }
    }
}
