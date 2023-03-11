using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Interfaces;

namespace uchpr.Models
{
    public class Order : IOrderInfo
    {
        public string date { get; set; }
        public int client_code { get; set; }
        public int service_code { get; set; }
        public int employee_code { get; set; }
        public int discount { get; set; }
        public string state { get; set; }
    }
}
