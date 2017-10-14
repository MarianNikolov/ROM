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

        [Required(ErrorMessage = ProductConstants.NameIsRequired)]
        [MinLength(ProductConstants.ProductNameMinLength)]
        [MaxLength(ProductConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = ProductConstants.QuantityIsRequired)]
        public int Quantity { get; set; }

        public QuantityType QuantityType { get; set; }

        public ProductType ProductType { get; set; }

        [Required(ErrorMessage = ProductConstants.PriceIsRequired)]
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
