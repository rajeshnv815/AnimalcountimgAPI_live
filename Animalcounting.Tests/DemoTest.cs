using AnimalAPI;
using AnimalAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Animalcounting.Tests
{
    public class DemoTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1==1);
        }

        [Fact]

        public async Task CustomerIntegrationTest()
        {
            //Create DB context
        
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

                var optionsBuilder = new DbContextOptionsBuilder<CustomerDbcontext>();
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

                var context= new CustomerDbcontext(optionsBuilder.Options);

            //Delete existing from the table
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            /* context.customers.RemoveRange(await context.customers.ToArrayAsync());
             await context.SaveChangesAsync();*/
            //Create controller

            var controller =new CustomerController(context);
            //Add Customer
            
            await controller.Add(new customer() { name = "Jai" });
        //Check : Does Get all return values.

            var result= (await controller.GetAll()).ToArray();  
            Assert.Single(result);
            Assert.Equal("Jai", result[0].name);
    }
    }
}