using FluentAssertions;
using NUnit.Framework;
using PimaDoctor.Controllers;
using PimaDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Controllers
{
    [TestFixture]
    class UserControllerTests
    {
        [Test]
        public void GetAllUsersTest()
        {
            var users = UserController.All();
            users.Should().BeOfType<List<User>>();
        }

        [Test]
        public void AddUserTest()
        {
            UserController.Add("addUserTest", "testPassword");
            var user = UserController.GetByLogin("addUserTest");
            user.Should().BeOfType<User>();
            UserController.Delete(user.Id);
        }

        [Test]
        public void UpdateUserTest()
        {
            UserController.Add("updateUserTest", "testPassword");
            var beforeUpdateUser = UserController.GetByLogin("updateUserTest");
            beforeUpdateUser.Should().BeOfType<User>();
            UserController.Update(beforeUpdateUser.Id, "testPassword2", null);
            var afterUpdateUser = UserController.GetByLogin("updateUserTest");
            afterUpdateUser.Should().BeOfType<User>();
            afterUpdateUser.Password.Should().NotBe(beforeUpdateUser.Password);
            UserController.Delete(beforeUpdateUser.Id);
        }
    }
}
