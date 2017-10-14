using ROM.Data.Model;

namespace ROM.Services.Data.Contracts
{
    public interface IUserRoleService
    {
        void AddRole(User user, string roleName);
    }
}
