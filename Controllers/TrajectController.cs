using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDKTest.BusinessLogic;
using SDKTest.Data.Entities;

namespace SDKTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrajectController : ControllerBase
    {
        IEmployeeLogic employeeLogic;

        public TrajectController(IEmployeeLogic employeeLogic)
        {
            this.employeeLogic = employeeLogic;
        }

        // GET: api/Traject
        [HttpGet]
        public IActionResult GetTrajects()
        {
            return Ok(employeeLogic.GetAllTrajects());
        }

        // GET: api/Traject/5
        /*[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Traject
        [HttpPost]
        public IActionResult Post(Guid employeeId, [FromBody] Traject traject)
        {
            try
            {
                employeeLogic.AddEmployeeTravel(employeeId, traject);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT: api/Traject/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
