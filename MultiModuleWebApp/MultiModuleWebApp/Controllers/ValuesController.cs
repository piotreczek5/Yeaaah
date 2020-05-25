using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using CoreImplementation.Database;
using CoreImplementation.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MultiModuleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IDataBase _database;
        public ValuesController(IDataBase database)
        {
            _database =  database;
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //   // var menuItems = _database.GetByType<MenuItem>();
        //    return new string[] {  };
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
