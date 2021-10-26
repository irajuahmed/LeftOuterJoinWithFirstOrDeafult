using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftOuterJoinWithFirstOrDeafult
{
    class Program
    {
        static void Main(string[] args)
        {
            LeftOuterJoinExample();
            Console.ReadKey();
        }

        public static void LeftOuterJoinExample()
        {
            // Create two lists.
            List<CustomerInformation> customerList = new List<CustomerInformation>
            {
                new CustomerInformation{Id=1, FirstName="Raju",   LastName="Ahmed"},
                new CustomerInformation{Id=2, FirstName="Tahira", LastName="Biswas"},
                new CustomerInformation{Id=3, FirstName="Shohag", LastName="Mia"},
                new CustomerInformation{Id=4, FirstName="Saiful", LastName="Islam"}
            };

            List<CustomerVisitHistory> customerVisitHisorys = new List<CustomerVisitHistory>
            {
                new CustomerVisitHistory{Id=1,CustomerId=1,VisitDate="2021-01-01"},
                new CustomerVisitHistory{Id=2,CustomerId=1,VisitDate="2021-01-01"},
                new CustomerVisitHistory{Id=3,CustomerId=2,VisitDate="2021-01-01"},
                new CustomerVisitHistory{Id=4,CustomerId=2,VisitDate="2021-01-01"},
                new CustomerVisitHistory{Id=5,CustomerId=3,VisitDate="2021-01-01"},
                new CustomerVisitHistory{Id=6,CustomerId=3,VisitDate="2021-01-01"}
            };

             
            var customerVisit = from c in customerList
                                join cv in customerVisitHisorys.AsQueryable() on c.Id equals cv.CustomerId into cvGroup
                                from cvHistory in cvGroup.OrderByDescending(cvr => cvr.CustomerId).Take(1).DefaultIfEmpty()
                                select new CustomerVisitDetails
                                {
                                    CustomerId = c.Id,
                                    FullName = c.FirstName + " " + c.LastName,
                                    VisitDate=cvHistory==null?"": cvHistory.VisitDate
                                };
            foreach (var cust in customerVisit)
            {
                Console.WriteLine("Customer No :{0} | Customer Name: {1} | Visit Date: {2}",cust.CustomerId,cust.FullName,cust.VisitDate);
            }
            Console.ReadKey();

        }
    }
    class CustomerVisitDetails
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string VisitDate { get; set; }
    }
    class CustomerInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class CustomerVisitHistory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string VisitDate { get; set; }
    }


}
