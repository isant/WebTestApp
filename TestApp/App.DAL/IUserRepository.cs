using System.Collections.Generic;

namespace App.DAL
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(int id);
        UserModel GetUserByUserName(string username);
        bool UserExistById(int id);        
        int AddNewUser(UserModel user);
        bool UpdateUser(UserModel user);
        IEnumerable<RolModel> GetRoles();
        
    }
}
