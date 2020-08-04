using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return;
                //context.Contacts.RemoveRange(context.Contacts);
            }

            //Add TestData
            var customers = new Customer[]
            {
            new Customer{Email = "Sten@gmail.com", Phone = "123456789", FullName ="Sten" },
            new Customer{Email = "Stev@gmail.com", Phone = "123456789", FullName = "Stev" }
            };

            foreach(Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }

    }
}
