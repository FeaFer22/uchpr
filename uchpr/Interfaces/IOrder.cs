using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uchpr.Interfaces
{
    internal interface IOrder
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Discount { get; set; }
        public string State { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public string EmployeeName { get; set; }
    }
}
