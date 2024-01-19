using Microsoft.AspNetCore.Mvc;
using Storage.Repositories;

namespace Storage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;


        public CustomerController(
            CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] long id)
        {
            var query = _customerRepository.GetCustomer(id);

            return Ok(query);
        }
    }
}