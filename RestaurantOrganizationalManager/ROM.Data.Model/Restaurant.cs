using ROM.Data.Model.Abstracts;
using System.Collections.Generic;

namespace ROM.Data.Model
{
    public class Restaurant : BaseModel
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