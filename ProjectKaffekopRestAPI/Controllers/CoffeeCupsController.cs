using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectKaffekop.Core.AppService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeCupsController : ControllerBase
    {
        private readonly IKaffekopService _kaffekopService;

        public CoffeeCupsController(IKaffekopService kaffekopService)
        {
            _kaffekopService = kaffekopService;
        }
        // GET api/coffeeCups -- read all
        [HttpGet]
        public ActionResult<IEnumerable<CoffeeCup>> GetAllCoffeCups()
        {
            return _kaffekopService.GetAllCups();
        }

        // GET api/coffeeCups/5 -- read by Id
        [HttpGet("{id}")]
        public ActionResult<CoffeeCup> Get(int id)
        {
            return _kaffekopService.GetCoffeeCupById(id);
        }

        // POST api/coffeeCups --Create JSON
        [HttpPost]
        public ActionResult<CoffeeCup> Post([FromBody] CoffeeCup coffeeCup)
        {
            return _kaffekopService.CreateCoffeeCup(coffeeCup);
        }

        // PUT api/coffeeCups/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<CoffeeCup> Put(int id, [FromBody] CoffeeCup coffeeCup)
        {
            if (id < 1 || id != coffeeCup.Id)
            {
                return BadRequest("Parameter Id and CoffeeCup id must be the same");
            }
            return Ok(_kaffekopService.UpdateCoffeeCup(coffeeCup));
        }

        // DELETE api/coffeeCups/5
        [HttpDelete("{id}")]
        public ActionResult<CoffeeCup> Delete(int id)
        {
            var cc = _kaffekopService.DeleteCoffeeCup(id);
            if (cc == null)
            {
                return StatusCode(404, "Did not find any Coffee Cups with the Id" + id);
            }

            return NoContent();
        }
    }
}