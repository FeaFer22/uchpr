using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Interfaces;

namespace uchpr.Models
{
    class Service : IService
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
    }
}
