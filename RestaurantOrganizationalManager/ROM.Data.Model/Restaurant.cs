using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROM.Data.Model
{
    public class Restaurant
    {
        private ICollection<Table> table;

        public Restaurant()
        {
            this.table = new HashSet<Table>();
        }

        public string Name { get; set; }


        public virtual ICollection<Table> Tables
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }
    }
}