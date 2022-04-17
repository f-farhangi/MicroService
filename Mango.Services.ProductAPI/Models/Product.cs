using System;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class Product
    {
        #region Properties

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1,1000)]
        public double Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string CategoryName { get; set; }

        [MaxLength(1000)]
        public string ImageUrl { get; set; }

        #endregion
    }
}
