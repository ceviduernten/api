using DUR.Api.Entities.Admin;

namespace DUR.Api.Services.Interfaces
{
    public interface IUserService : IDatabaseService<User>
    {
        string ValidateUser(User user);
        User GetByUsername(string username);
        new User Add(User user);
    }
}
