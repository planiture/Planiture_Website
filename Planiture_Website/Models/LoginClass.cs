using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Planiture_Website.Models
{
    public class LoginClass
    {
        public string ID { get; set; }
        [DisplayName("User Name")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string CustomerID { get; set; }
    }
}
