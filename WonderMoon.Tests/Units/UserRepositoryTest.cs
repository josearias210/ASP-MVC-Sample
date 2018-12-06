using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using Wonder.Core.Models;
using Wonder.Infrastructure.Repositories.EF;
using Wonder.Infrastructure.Seeders;

namespace WonderMoon.Tests.Units
{
    [TestClass]
    public class UserRepositoryTest
    {
        private UserRepository repository;

        [TestInitialize]
        public void TestSetup()
        {
            var db = new SeederInitalizeTest();
            Database.SetInitializer(db);
            repository = new UserRepository();
        }
        

        [TestMethod]
        public void AddNewUser()
        {
            var user = CreateUserMaria();

            var userDB = repository.FindBy(x => x.EmailAddress == "maria@gmail.com").FirstOrDefault();

            Assert.IsNotNull(userDB);

        }

        [TestMethod]
        public void UpdateRol()
        {
            var user = CreateUserMaria();

            var userEdit = repository.FindBy(x => x.EmailAddress == "maria@gmail.com").FirstOrDefault();
            userEdit.EmailAddress = "lorena@gmail.com";
            userEdit.FirstName = "lorena";
            userEdit.SecondName = "cruz";
            userEdit.MobilePhone = "11111";
            userEdit.PrimaryAddress = "calle 3, carrera 4";

            repository.EditUser(userEdit);

            var userQuery = repository.FindBy(x => x.EmailAddress == "lorena@gmail.com").FirstOrDefault();

            var change = userQuery.EmailAddress == userEdit.EmailAddress && userQuery.FirstName == userEdit.FirstName
                         && userQuery.SecondName == userEdit.SecondName && userQuery.PrimaryAddress == userEdit.PrimaryAddress
                         && userQuery.MobilePhone == userEdit.MobilePhone && userQuery.UserId == userEdit.UserId;

            Assert.IsTrue(change);

        }


        [TestMethod]
        public void DeleteUser()
        {
            bool delete = false;

            var userQuery = CreateUserMaria();
            repository.DeleteUser(userQuery.UserId);
            var userFound = repository.FindBy(x => x.UserId == userQuery.UserId).FirstOrDefault();
            delete = userFound == null;

            Assert.IsTrue(delete);

        }



        [TestMethod]
        public void FindByUser()
        {

            var user = CreateUserMaria();

            var userFound = repository.FindBy(x => x.EmailAddress == "maria@gmail.com").FirstOrDefault();

            Assert.IsNotNull(userFound);

        }

        [TestMethod]
        public void GetRolByUser()
        {
            Rol rol = null;

            var userSave = CreateUserMaria();
            var resultado = repository.GetUser(userSave.UserId);
            if (resultado.IsSuccess)
            {
                rol = resultado.Data.Rol;
            }

            Assert.IsNotNull(rol);
        }

        #region Privates
        private User CreateUserMaria()
        {
            var user = new User
            {
                EmailAddress = "maria@gmail.com",
                FirstName = "maria",
                SecondName = "lara",
                HomePhone = "12345",
                MobilePhone = "85224",
                PrimaryAddress = "calle 1, carrera 2",
                RolId = 1
            };

            var resultado = repository.RegisterUser(user);
            if (resultado.IsSuccess)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}