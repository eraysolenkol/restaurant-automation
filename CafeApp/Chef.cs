using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class Chef : Employee
    {
    public Chef(int id, string name, string surname, string phoneNumber, DateTime birthDate, DateTime joinTime, string job, string email, string gender)
        : base(id, name, surname, phoneNumber, birthDate, joinTime, job, email, gender)
        {

        }

        public void prepareFood(OrderDetails orderDetails)
        {
            OrderDetails.orderIsReady(orderDetails);
        }
    }
}
