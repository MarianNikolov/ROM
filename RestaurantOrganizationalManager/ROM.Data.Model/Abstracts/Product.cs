using ROM.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROM.Data.Model.Abstracts
{
    public abstract class Product : BaseModel
    {
        public string Name { get; set; }

        public Quantity Quantity { get; set; }
    }
}
