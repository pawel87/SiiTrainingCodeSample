using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiiTraining.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //GET api/values
        [HttpGet]
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2" };
        }

        //POST api/values
        [HttpPost]
        public void PostValue([FromBody] string value)
        {
            //...
        }

        //PUT api/values/1
        [HttpPut("{id}")]
        public void PostUpdate(int id, [FromBody] string value)
        {
            //...
        }

        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return "item " + id;
        }
    }
}