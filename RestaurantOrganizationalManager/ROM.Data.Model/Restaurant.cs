using ROM.Common;
using ROM.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ROM.Data.Model
{
    public class Restaurant : BaseModel
    {
        private ICollection<Table> tables;
        private ICollection<User> users;

        public Restaurant()
        {
            this.tables = new HashSet<Table>();
            this.users = new HashSet<User>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(RestaurantConstants.RestaurantNameMinLength)]
        [MaxLength(RestaurantConstants.RestaurantNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Table> Tables
        {
            get { return this.tables; }
            set { this.tables = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}