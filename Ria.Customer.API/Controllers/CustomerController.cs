using Microsoft.AspNetCore.Mvc;
using Ria.CustomerAPI.Models;
using Ria.CustomerAPI.Services;
using System.Collections.Generic;

namespace Ria.CustomerAPI.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {

        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Customer> customers)
        {
            var errors = _service.InsertCustomers(customers);

            if (errors.Count > 0)
                return BadRequest(errors);

            return Ok("Customers added successfully.");
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());


        public IActionResult Index()
        {
            return View();
        }

    }
}
