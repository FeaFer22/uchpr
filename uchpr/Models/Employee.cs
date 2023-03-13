using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Interfaces;

namespace uchpr.Models
{
    public class Employee : IEmployee
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
