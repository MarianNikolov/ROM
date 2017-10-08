using ROM.Common;
using ROM.Data.Model.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ROM.Data.Model
{
    public class Product : BaseModel
    {
        private ICollection<Table> tables;

        public Product()
        {
            this.tables = new HashSet<Table>();
        }

        [Required]
        [MinLength(RestaurantConstants.RestaurantNameMinLength)]
        [MaxLength(RestaurantConstants.RestaurantNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public QuantityType QuantityType { get; set; }

        public ProductType ProductType { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public virtual ICollection<Table> Tables
        {
            get
            {
                return this.tables;
            }
            set
            {
                this.tables = value;
            }
        }
    }
}
