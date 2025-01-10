using Asp.Versioning;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWebAPI.Controllers
{
    [Route("api/v{v:apiVersion}/students")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        [MapToApiVersion(1)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [MapToApiVersion(2)]
        [HttpGet]
        public IEnumerable<string> Get2()
        {
            return new string[] { "value3", "value4" };
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            Student studentt = new Student
            {
                id = 1,
                name = "Test",
                age = 30,
                address = "address",
            };
            return Ok(studentt);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "ok";
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
