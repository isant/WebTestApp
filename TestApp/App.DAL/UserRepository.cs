using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{    
    public class UserRepository : IUserRepository
    {
        PersistingDataSet dataSet;

        public UserRepository()
        {            
             dataSet = new PersistingDataSet();      
        }

        public int AddNewUser(UserModel user)
        {
            return dataSet.AddNewUser(user);
        }

        public UserModel GetUserById(int id)
        {
            var userList = dataSet.GetUsers();

            UserModel userReturn = userList.Where(x => x.Id == id).FirstOrDefault();

            return userReturn;
        }

        public UserModel GetUserByUserName(string username)
        {
            var userList = dataSet.GetUsers();

            UserModel userReturn = userList.Where(
                x => x.UserName.ToLowerInvariant() == username.ToLowerInvariant()).FirstOrDefault();

            return userReturn;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return dataSet.GetUsers();
        }

        public bool UpdateUser(UserModel user)
        {
           return dataSet.UpdateUser(user);
        }

        public bool UserExistById(int id)
        {
            bool flag = false;

            var userList = dataSet.GetUsers();

            UserModel userResult = userList.Where(x => x.Id == id).FirstOrDefault();

            if (userResult != null)
            {
                flag = true;
            }

            return flag;
        }

        public IEnumerable<RolModel> GetRoles()
        {
            return dataSet.GetRoles();
        }
    }
}
