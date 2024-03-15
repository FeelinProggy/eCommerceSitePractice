using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSitePractice.Models
{
    /// <summary>
    /// Represents products for sale on the site
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier for each product
        /// </summary>
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// The category of the product
        /// </summary>
        [Required]
        public required string Category { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// A description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The sale price of the product
        /// </summary>
        [Range(0,200)]
        public double Price { get; set; }
        
    }

    /// <summary>
    /// Represents a product that has been added
    /// to the users shopping cart cookie
    /// </summary>
    public class CartProductViewModel
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }


        
    }
}
