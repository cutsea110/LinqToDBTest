using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataModels;

namespace LinqToDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AdventureWorks2016DB())
            {
                var q =
                    from c in db.Customers
                    select new
                    {
                        CustomerName = $"{c.Person.FirstName} {c.Person.MiddleName} {c.Person.LastName}",
                        OrderCount = c.SalesOrderHeaderCustomerIds.Count(),
                    };

                foreach (var c in q)
                    Console.WriteLine(c);
            }
        }
    }
}
