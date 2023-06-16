using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class Cashier: Employee
    {

    public Cashier(int id, string name, string surname, string phoneNumber, DateTime birthDate, DateTime joinTime, string job, string email, string gender)
        : base(id, name, surname, phoneNumber, birthDate, joinTime, job, email, gender)
        {

        }


        public void takePay(List<Order> orders, Table table)
        {
            foreach (Order order in orders)
            {
                Order.payOrder(order.orderId);
            }
            table.setTable(true);
        }
    }
}
