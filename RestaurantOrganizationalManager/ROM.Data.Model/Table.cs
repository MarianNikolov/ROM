using ROM.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROM.Data.Model
{
    public class Table : BaseModel
    {
        private ICollection<Product> products;

        public Table()
        {
            this.products = new HashSet<Product>();
            this.IsFree = true;
        }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        [Required]
        public int Number { get; set; }

        public bool IsFree { get; set; }

        public virtual Guid? RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
