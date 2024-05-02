using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriantaWeb.API.Controllers
{
    //https://localhost/:portnumber/api/employee
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            string[] employees = new string[] { "Dimitris", "Apostolis" };
            
            return Ok(employees);
        }
    }
}
