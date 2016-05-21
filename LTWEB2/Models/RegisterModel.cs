using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWEB2.Models
{
    public class RegisterModel
    {
        public string UID { get; set; }
        public string PWD { get; set; }
        public decimal SDT { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

    }
}