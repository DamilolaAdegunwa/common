using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace ASPNETWebFormsApplication.Models
{
    #region entity class
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }
        [Required, StringLength(10000), Display(Name = "Product Description"),
        DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    #endregion

    #region context class
    public class ProductContext : DbContext
    {
        public ProductContext() : base("WingtipToys")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    #endregion
}