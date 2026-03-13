using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Models;

[Table("inventory")]
public partial class Inventory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("itemname")]
    [StringLength(150)]
    public string Itemname { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    [Column("createddate", TypeName = "timestamp without time zone")]
    public DateTime? Createddate { get; set; }
}
