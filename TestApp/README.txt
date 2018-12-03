To run this project please open the solution using Visual Studio. If there is any reference problem
please use restore nuget packages. You might have some issue with newtonsoft dll at WebApi project, however this library is not being used
but seems like it have some dependency with Webgrease dll so I couldn't remove the reference

Once the solution is built proceed to set the proyect App.WebApi as startup project and run the solution
The browser will display the initial asp .net page.

Now you can test the API using POSTMAN, you can import the postman profile attached to the solution

Please find below some data details about the solution.

The Dataset contains the following initial information:

ROLES
roleAdmin { Id = 1, Name = "ADMIN", Description = "Admin role." };
roleP1 { Id = 2, Name = "PAGE_1", Description = "Role for page 1." };
roleP2 { Id = 3, Name = "PAGE_2", Description = "Role for page 2." };
roleP3 { Id = 4, Name = "PAGE_3", Description = "Role for page 3." };

USERS
UserModel Admin = new UserModel() { Id = 1, UserName = "AdminUser", Roles = new List<RolModel> { roleAdmin }, Password = "admin" };
UserModel user1 = new UserModel() { Id = 2, UserName = "User1", Roles = new List<RolModel> { roleP1 }, Password = "user1" };
UserModel user2 = new UserModel() { Id = 3, UserName = "User2", Roles = new List<RolModel> { roleP2 }, Password = "user2" };
UserModel user3 = new UserModel() { Id = 4, UserName = "User3", Roles = new List<RolModel> { roleP3 }, Password = "user3" };
UserModel user4 = new UserModel() { Id = 5, UserName = "User3", Roles = new List<RolModel> { roleP1, roleP3 }, Password = "user4" };


Get registered users:
GET 
http://localhost:54816/getusers/1/admin --> OK, returns the list
http://localhost:54816/getusers/2/user1 --> Forbidden, return access denied


Create new user:
POST
http://localhost:54816/CreateUser
{
   "Id":0,
   "UserName":"NewUser",
   "Password":"newuser",
   "Roles":[
      {
         "Id":1,
         "Name":"ADMIN",		 
         "Description":"Admin role."
      }
   ]
}

Update user with id=3:
POST
http://localhost:54816/UpdateUser
{
   "Id":3,
   "UserName":"UpdatedUser",
   "Password":"updatedUser",
   "Roles":[
      {
         "Id":3,
         "Name":"PAGE_2",		 
         "Description":"role for page 2"
      }
   ]
}

In order to test this solution you have a Unittest Project. To run it please select Test Explorer and run all tests
To test the API you can use the POSTMAN profile attached along with this "readme" file