using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int CustomerName { get; set; }
        public int CustomerSurname { get; set; }
        public int CustomerMail { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
    }
}
