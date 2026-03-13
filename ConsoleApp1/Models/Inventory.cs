using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        public string Itemname { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 10000, ErrorMessage = "Enter valid quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000000, ErrorMessage = "Enter valid price")]
        public decimal Price { get; set; }
    }
}
