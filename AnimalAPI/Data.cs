using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AnimalAPI
{
    public class customer
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
    public class CustomerDbcontext : DbContext
    {
        
        public CustomerDbcontext(DbContextOptions<CustomerDbcontext> options): base(options) { }
        public DbSet<customer> customers { get; set; }
    }
}
