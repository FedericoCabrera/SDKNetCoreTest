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
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic employeeLogic;
        SDKTest.Data.DataAccess.SDKTestDbContext context;

        public EmployeeController(IEmployeeLogic employeeLogic, SDKTest.Data.DataAccess.SDKTestDbContext c)
        {
            this.context = c;
            this.employeeLogic = employeeLogic;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {

                return Ok(employeeLogic.GetAllEmployees());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                employeeLogic.AddEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
