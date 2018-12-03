using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class PersistingDataSet
    {
        //I'll keep data in memory and simulate somehow a db behavior;
        private List<UserModel> RegisteredUsers;
        private List<RolModel> RegisteredRoles;

        public PersistingDataSet()
        {
            RolModel roleAdmin = new RolModel() { Id = 1, Name = "ADMIN", Description = "Admin role." };
            RolModel roleP1 = new RolModel() { Id = 2, Name = "PAGE_1", Description = "Role for page 1." };
            RolModel roleP2 = new RolModel() { Id = 3, Name = "PAGE_2", Description = "Role for page 2." };
            RolModel roleP3 = new RolModel() { Id = 4, Name = "PAGE_3", Description = "Role for page 3." };

            RegisteredRoles = new List<RolModel>() { roleAdmin, roleP1, roleP2, roleP3 };            

            UserModel Admin = new UserModel() { Id = 1, UserName = "AdminUser", Roles = new List<RolModel> { roleAdmin }, Password = "admin" };
            UserModel user1 = new UserModel() { Id = 2, UserName = "User1", Roles = new List<RolModel> { roleP1 }, Password = "user1" };
            UserModel user2 = new UserModel() { Id = 3, UserName = "User2", Roles = new List<RolModel> { roleP2 }, Password = "user2" };
            UserModel user3 = new UserModel() { Id = 4, UserName = "User3", Roles = new List<RolModel> { roleP3 }, Password = "user3" };
            UserModel user4 = new UserModel() { Id = 5, UserName = "User3", Roles = new List<RolModel> { roleP1, roleP3 }, Password = "user4" };
            RegisteredUsers = new List<UserModel>() { Admin, user1, user2, user3, user4 };
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return RegisteredUsers;
        }

        public IEnumerable<RolModel> GetRoles()
        {
            return RegisteredRoles;
        }

        public int AddNewUser(UserModel user)
        {
            int id = RegisteredUsers.Max(x => x.Id);
            user.Id = id + 1;
            RegisteredUsers.Add(user);
            return user.Id;
        }

        public bool UpdateUser(UserModel user)
        {
            bool flag = false;
            try
            {
                if (RegisteredUsers.Exists(x => x.Id == user.Id))
                {
                    UserModel userToEdit = RegisteredUsers.Find(x => x.Id == user.Id);

                    if (userToEdit != null)
                    {
                        if (userToEdit.Roles != user.Roles)
                            userToEdit.Roles = user.Roles;

                        if (userToEdit.UserName != user.UserName)
                            userToEdit.UserName = user.UserName;

                        if (userToEdit.Password != user.Password)
                            userToEdit.Password = user.Password;

                        flag = true;
                    }
                    else
                        flag = false;
                }
                else
                    flag = false;
            }
            catch
            {
                flag = false;
            }

            return flag;
        }
    }
}
