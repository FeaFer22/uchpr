using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Interfaces;

namespace uchpr.Models
{
    public class User : IUserInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
