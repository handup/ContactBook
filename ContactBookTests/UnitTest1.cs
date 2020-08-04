using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBook.Controllers;
using ContactBook.Models;
using ContactBook.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Tests
{
    public class ItemsControllerTest { 

    protected ItemsControllerTest(DbContextOptions<CustomerContext> context)
    {
        ContextOptions = context;

        Seed();
    }

    protected DbContextOptions<CustomerContext> ContextOptions { get; }

    private void Seed()
    {
        using (var context = new CustomerContext(ContextOptions))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Customers.Add(new Customer 
                { FullName= "Stev", Email = "stevia", Phone= "51215" }
            );

            context.SaveChanges();
        }
    }
    }

    [TestClass]
    public class TestSimpleCustomerController : ItemsControllerTest
    {
        public TestSimpleCustomerController()
        : base(
            new DbContextOptionsBuilder<CustomerContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {
            using (var context = new CustomerContext(ContextOptions))
            {
                var controller = new CustomersController(context);

                var result = controller.Get() as List<Customer>;
                
                Assert.AreEqual(1, result.Count);
            }
        }

        [TestMethod]
        public void ThisIsAUnitTest()
        {
            Assert.AreEqual(true, true);
        }
    }
}