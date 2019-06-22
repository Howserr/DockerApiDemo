using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DockerApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new ActionResult<IEnumerable<string>>(new List<string>{ "Max", "Daniel", "Kimi"});
        }
    }
}