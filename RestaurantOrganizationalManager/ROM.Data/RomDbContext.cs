using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using ROM.Data.Model.Contracts;
using ROM.Data.Model;

namespace ROM.Data
{
    public class RomDbContext : IdentityDbContext<User>
    {
        public RomDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Restaurant> Restaurants { get; set; }

        public IDbSet<Table> Tables { get; set; }

        public IDbSet<Product> Products { get; set; }
        

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }

        public static RomDbContext Create()
        {
            return new RomDbContext();
        }
    }
}
