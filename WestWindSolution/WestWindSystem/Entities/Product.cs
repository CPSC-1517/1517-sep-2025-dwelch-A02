using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.Entities;

[Index("CategoryID", Name = "CategoriesProducts")]
[Index("CategoryID", Name = "CategoryID")]
[Index("ProductName", Name = "ProductName")]
[Index("SupplierID", Name = "SupplierID")]
[Index("SupplierID", Name = "SuppliersProducts")]
public partial class Product
{
    [Key]
    public int ProductID { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; }

    public int SupplierID { get; set; }

    public int CategoryID { get; set; }

    [Required]
    [StringLength(20)]
    public string QuantityPerUnit { get; set; }

    public short? MinimumOrderQuantity { get; set; }

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    public int UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }

    [ForeignKey("CategoryID")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SupplierID")]
    [InverseProperty("Products")]
    public virtual Supplier Supplier { get; set; }
}
