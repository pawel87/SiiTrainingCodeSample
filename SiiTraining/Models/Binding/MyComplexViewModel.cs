using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Models.Binding
{
    public class MyComplexViewModel
    {
        public int Id { get; set; }

        [BindRequired]
        public int? InternalId { get; set; }

        [BindNever]
        public string Password { get; set; }

        [FromQuery]
        public string Language { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string BrowserLanguage { get; set; }

        [FromRoute(Name = "category")]
        public int CategoryId { get; set; }
    }
}
