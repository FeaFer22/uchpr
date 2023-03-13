using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uchpr.Interfaces
{
    internal interface IService
    {
        int id { get; set; }
        string name { get; set; }
        string description { get; set; }
        string price { get; set; }
    }
}
