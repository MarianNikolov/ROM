using ROM.Data.Model.Abstracts;
using System.Collections.Generic;

namespace ROM.Data.Model
{
    public class Product : BaseModel
    {
        private ICollection<Table> tables;

        public Product()
        {
            this.tables = new HashSet<Table>();
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public QuantityType QuantityType { get; set; }

        public ProductType ProductType { get; set; }

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
