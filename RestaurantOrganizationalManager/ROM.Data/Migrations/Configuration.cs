namespace ROM.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ROM.Data.Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        private const string AdministratorUserName = "admin@abv.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DbContext context)
        {
            this.SeedUsers(context);
            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedUsers(DbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleData(DbContext context)
        {
            if (!context.Restaurants.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var restaurant = new Restaurant()
                    {
                        Name = "Restaurant " + i,
                        CreatedOn = DateTime.Now
                    };

                    context.Restaurants.Add(restaurant);
                }
            }
        }
    }
}
