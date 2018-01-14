using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    [ViewComponent]
    public class SimpleClass
    {
        public async Task<string> InvokeAsync()
        {
            //some logic

            await Task.Delay(1000);

            return "Success from C# code";
        }
    }
}
