namespace ROM.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ROM.Data.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<RomDbContext>
    {
        private const string AdministratorUserName = "admin@abv.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(RomDbContext context)
        {
            this.SeedData(context);
            this.SeedAll(context);
            base.Seed(context);
        }

        private void SeedAll(RomDbContext context)
        {
            if (!context.Restaurants.Any())
            {
                var roleName = "Manager";
                var userNames = new List<string>() { "aaa@abv.bg", "bbb@abv.bg", "ccc@abv.bg", };
                var userPasswords = new List<string>() { "aaaaaa", "bbbbbb", "cccccc", };
                var restaurantNames = new List<string>() { "Cosmos", "Chef's", "Wok to Walk" };

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                for (int i = 0; i < userNames.Count; i++)
                {
                    var restaurant = new Restaurant()
                    {
                        Name = restaurantNames[i],
                        CreatedOn = DateTime.Now
                    };


                    var user = new User
                    {
                        UserName = userNames[i],
                        Email = userNames[i],
                        EmailConfirmed = true,
                        CreatedOn = DateTime.Now,
                        RestaurantID = restaurant.Id
                    };

                    context.Restaurants.Add(restaurant);


                    for (int j = 1; j <= 8; j++)
                    {
                        var table = new Table()
                        {
                            Number = j,
                            CreatedOn = DateTime.Now
                        };

                        context.Tables.Add(table);
                        restaurant.Tables.Add(table);
                    }
                    
                    userManager.Create(user, userPasswords[i]);
                    userManager.AddToRole(user.Id, roleName);
                }

                // Drinks
                var drinkNamesAndQuantity = new List<Tuple<string, int>>()
                {
                  new Tuple<string, int>("Coca Cola", 250 ),
                  new Tuple<string, int>("Water", 250 ),
                  new Tuple<string, int>("Water", 500 ),
                  new Tuple<string, int>("Beer", 500),
                  new Tuple<string, int>("Juice", 200),
                };
                var drinkPrices = new List<decimal>()
                {
                    (decimal)5.00,
                    (decimal)2.00,
                    (decimal)3.00,
                    (decimal)7.00,
                    (decimal)3.20
                };
                for (int i = 0; i < drinkNamesAndQuantity.Count; i++)
                {
                    context.Products.Add(new Product()
                    {
                        Name = drinkNamesAndQuantity[i].Item1,
                        Quantity = drinkNamesAndQuantity[i].Item2,
                        ProductType = ProductType.Drink,
                        QuantityType = QuantityType.Milliliters,
                        Price = drinkPrices[i]
                    });
                }

                // Foods
                var foodNamesAndQuantity = new List<Tuple<string, int>>()
                {
                    new Tuple<string, int>("Chicken casserole", 800 ),
                    new Tuple<string, int>("Pasta with salmon & peas", 600 ),
                    new Tuple<string, int>("Indian koftas with mint yogurt", 500 ),
                    new Tuple<string, int>("Chipotle chicken wraps", 800 ),
                    new Tuple<string, int>("Dude ranch tacos", 800 ),
                };
                var foodPrices = new List<decimal>()
                {
                    (decimal)6.20,
                    (decimal)9.40,
                    (decimal)12.80,
                    (decimal)15.99,
                    (decimal)15.20
                };
                for (int i = 0; i < foodNamesAndQuantity.Count; i++)
                {
                    context.Products.Add(new Product()
                    {
                        Name = foodNamesAndQuantity[i].Item1,
                        Quantity = foodNamesAndQuantity[i].Item2,
                        ProductType = ProductType.Food,
                        QuantityType = QuantityType.Grams,
                        Price = foodPrices[i]
                    });
                }
            }
        }

        private void SeedData(RomDbContext context)
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
                    CreatedOn = DateTime.Now,
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }
    }
}
