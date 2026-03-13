using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class User
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Pasword is required")]
        public string Password { get; set; }
    }
}
