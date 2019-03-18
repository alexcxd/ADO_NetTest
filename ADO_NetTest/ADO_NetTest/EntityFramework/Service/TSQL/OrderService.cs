using ADO_NetTest.EntityFramework.Model.TSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetTest.EntityFramework.Service.TSQL
{
    class OrderService
    {
        public void AddOrder(Order order)
        {
            using (var db = new BloggingContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void AddOrderList()
        {
            var rd = new Random();

            for (int i = 1; i <= 10000; i++)
            {
                int marId = 0;
                if (i > 10)
                {
                    marId = rd.Next(1, 10);
                }

                var order = new Order
                {
                    OrderId = i,
                    EmployeeId = rd.Next(10, 100),
                    Orders = DateTime.Now.AddDays(rd.Next(-365, 0)),
                    Qty = rd.Next(1, 10),
                    CustId = rd.Next(1, 100) + ""
                };

                AddOrder(order);
            }
        }

    }
}
