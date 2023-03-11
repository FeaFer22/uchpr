using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uchpr.Interfaces
{
    internal interface IOrderInfo
    {
        string date { get; set; }
        int client_code { get; set; }
        int service_code { get; set; }
        int employee_code { get; set; }
        int discount { get; set; }
        string state { get; set; }
    }
}
