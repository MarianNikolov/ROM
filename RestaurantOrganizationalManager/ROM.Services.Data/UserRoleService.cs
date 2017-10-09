using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ROM.Data.Model;
using ROM.Services.Data.Contracts;
using System.Data.Entity;

namespace ROM.Services.Data
{
    public class UserRoleService : IUserRoleService
    {
        private readonly DbContext context;
        public UserRoleService(DbContext context)
        {
            this.context = context;
        }

        public void AddRole(User user, string roleName)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = roleName };
            roleManager.Create(role);

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.AddToRole(user.Id, roleName);
        }
    }
}
