using DemoWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMyService _service1;
        private readonly IMyService _service2;
        public TestController(IMyService service1, IMyService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Service1 = _service1.GetOperationId(),
                Service2 = _service2.GetOperationId()
            });
        }
    }
}
