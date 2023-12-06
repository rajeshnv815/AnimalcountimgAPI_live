using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbcontext context;

        public CustomerController(CustomerDbcontext dbcontext)
        {
            this.context= dbcontext;
        }

        [HttpGet]

        public async Task<IEnumerable<customer>> GetAll() => await context.customers.ToArrayAsync();
        [HttpPost]
        public async Task<customer> Add([FromBody] customer newcustomer)
        {
             context.Add(newcustomer);
            await context.SaveChangesAsync();   
            return newcustomer;
        }
    }
}
