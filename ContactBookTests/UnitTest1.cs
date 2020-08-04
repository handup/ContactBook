using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBook.Controllers;
using ContactBook.Models;
using ContactBook.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactBook.Tests
{
    [TestClass]
    public class TestSimpleCustomerController
    {
        string dbName = Guid.NewGuid().ToString();
        DbContextOptions<CustomerContext> options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        private CustomerContext GetDatabaseContext()
        {
            
            var databaseContext = new CustomerContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {
            using (CustomerContext dbContext = new CustomerContext(options))
            {
                DbInitializer.Initialize(dbContext);
                var controller = new CustomersController(dbContext);

                var result = controller.Get().ToList();

                Assert.AreEqual(2, result.Count);
            }
        }
            

        [TestMethod]
        public void ThisIsAUnitTest()
        {
            Assert.AreEqual(true, true);
        }
    }
}