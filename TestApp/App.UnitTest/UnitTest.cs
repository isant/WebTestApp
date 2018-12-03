using System;
using System.Collections.Generic;
using System.Linq;
using App.Business;
using App.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        IUserRepository repository;
        IUserService service;
        ICustomMapper customMapper;

        public UnitTest()
        {
            repository = new UserRepository();
            customMapper = new CustomMapper();
            service = new UserService(repository, customMapper);            
        }
              
        //CUSTOMMAPPER TESTS
        [TestMethod]
        public void MapUserModelToUser()
        {
            User user = new User() { Id = 1, UserName = "test" };
            user.setPassword("testpass");

            UserModel umodel = customMapper.Map(user);          

            Assert.AreEqual(user.Id, umodel.Id);
            Assert.AreEqual(user.UserName, umodel.UserName);
            Assert.AreEqual(user.GetPassword(), umodel.Password);
        }

        [TestMethod]
        public void MapUserToUserModel()
        {
            UserModel userModel = new UserModel() { Id = 1, UserName = "test" };
            userModel.Password = "testpass";

            User user = customMapper.Map(userModel);

            Assert.AreEqual(userModel.Id, user.Id);
            Assert.AreEqual(userModel.UserName, user.UserName);
            Assert.AreEqual(userModel.Password, user.GetPassword());
        }

        [TestMethod]
        public void MapRolModelsToRoles()
        {            
            var r1 = new RolModel() { Id = 1, Description = "test1", Name = "test1" };
            var r2 = new RolModel() { Id = 2, Description = "test2", Name = "test2" };
            List<RolModel> RolModels = new List<RolModel>() {r1,r2 };          

            var roles = customMapper.Map(RolModels);
            Assert.AreEqual(roles.Count, RolModels.Count);            
        }


        //DAL TESTS
        [TestMethod]
        public void RepositoryUserExist()
        {
            RolModel roleP2 = new RolModel() { Id = 3, Name = "PAGE_2", Description = "Role for page 2." };                
            UserModel user2 = new UserModel() { Id = 3, UserName = "User2", Roles = new List<RolModel> { roleP2 }, Password = "user2" };

            UserModel uModel = repository.GetUserById(3);

            Assert.AreEqual(user2.Id, uModel.Id);
            Assert.AreEqual(user2.Password, uModel.Password);
            Assert.AreEqual(user2.UserName, uModel.UserName);
        }

        [TestMethod]
        public void RepositoryUserNotExist()
        {
            UserModel expected = null;

            UserModel uModel = repository.GetUserById(999);

            Assert.AreEqual(expected, uModel);            
        }

        [TestMethod]
        public void RepositoryUserUpdate()
        {         
            UserModel expected = repository.GetUserById(2);
            expected.UserName = "userUpdated";
            var response = repository.UpdateUser(expected);

            UserModel result = repository.GetUserById(2);
            Assert.AreEqual(expected.UserName, result.UserName);

        }

        [TestMethod]
        public void RepositoryUserUpdateNotExistingUser()
        {
            bool expected = false;

            UserModel updater = new UserModel();
            updater.UserName = "userUpdated";
            updater.Id = 999;
            var response = repository.UpdateUser(updater);           

            Assert.AreEqual(expected, response);
        }

        //BISINESS DAL
        [TestMethod]
        public void AuthenticationSuccess()
        {
            int expected = 0;
            int id = 1;
            string pass = "admin";
            var result = service.UserAutentication(id, pass);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AuthenticationFailedPass()
        {
            int expected = -1;
            int id = 2;
            string pass = "admin";
            var result = service.UserAutentication(id, pass);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AuthenticationFailedInvalidData()
        {
            int expected = -2;
            int id = service.GetUsers().Max(x => x.Id) + 3;
            string pass = "admin";
            var result = service.UserAutentication(id, pass);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateUserSuccess()
        {
            int expected = 0;

            User user = new User()
            {
                Id = 0,
                UserName = "NewUser",
                Roles = new List<Rol>() { new Rol() { Id = 2, Description = "", Name = "" } }
            };
            user.setPassword("nuevoUsuario");

            var result = service.CreateUser(user);

            Assert.AreNotEqual(expected, result);         

        }

        [TestMethod]
        public void UpdateUSerSuccess()
        {
            bool expected = true;

            User user = new User()
            {
                Id = 4,
                UserName = "UpdatedUser",
                Roles = new List<Rol>() { new Rol() { Id = 2, Description = "", Name = "" } }
            };
            user.setPassword("UsuarioActualizado");

            var result = service.UpdateUser(user);

            Assert.AreEqual(expected, result);
        }




    }
}
