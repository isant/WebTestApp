using System.Collections.Generic;

namespace App.Business
{
    public interface IUserService
    {
        int UserAutentication(int id, string password);
        int UserAutentication(User user);
        User GetUserById(int Id);
        IEnumerable<User> GetUsers();
        bool UpdateUser(User user);
        int CreateUser(User user);
        IEnumerable<Rol> GetRoles();
    }
}
