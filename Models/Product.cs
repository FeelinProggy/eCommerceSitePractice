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
}
