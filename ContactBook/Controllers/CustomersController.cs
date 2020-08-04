using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactBook.Data;
using ContactBook.Models;
using System.Security.Cryptography.X509Certificates;

namespace ContactBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }

        // GET: customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers;
        }

        // GET: customers/{name}
        [HttpGet("{name}")]
        public IEnumerable<Customer> GetByName([FromRoute] string name)
        {
            return _context.Customers.Where(x => x.FullName.Contains(name));
        }

        // POST: customers/new
        [HttpPost("new")]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(_context.Customers);
        }

    }
}