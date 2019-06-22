using System.Collections.Generic;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace DockerApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return new ActionResult<IEnumerable<Customer>>(_customersRepository.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return new ActionResult<Customer>(_customersRepository.Get(id));
        }
    }
}