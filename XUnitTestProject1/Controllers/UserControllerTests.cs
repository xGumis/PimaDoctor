using System;
using System.Collections.Generic;
using FluentAssertions;
using PimaDoctor.Controllers;
using PimaDoctor.Models;
using PimaDoctor.Utilities;
using Xunit;

namespace XUnitTestProject1.Controllers
{
    public class UserControllerTests
    {
        private int _roleId;
        
        public UserControllerTests()
        {
            var rc = new RoleController(true);

            try
            {
                _roleId = rc.GetByName("testRolePatient").Id;
            }
            catch (Exception e)
            {
                rc.Add("testRolePatient");
                _roleId = rc.GetByName("testRolePatient").Id;
            }
        }
        
        [Fact]
        public void GetUserTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            user.Should().BeOfType<User>();
            uc.Delete(user.Id);
        }
        
        [Fact]
        public void GetAllUsersTest()
        {
            var uc = new UserController(true);
            var roles = uc.All();
            roles.Should().BeOfType<List<User>>();
        }
        
        [Fact]
        public void GetUserByNameTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            user.Should().BeOfType<User>();
            uc.Delete(user.Id);
        }

        [Fact]
        public void UpdateUserTest()
        {
            var rc = new RoleController(true);
            rc.Add("anotherTestRole");
            var role = rc.GetByName("anotherTestRole");
            
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            
            uc.Update(user.Id, "updatedUser", role.Id);
        
            user.Should().BeOfType<User>();
            uc.Delete(user.Id);
            rc.Delete(role.Id);
        }
        
        [Fact]
        public void UpdateUserNullNameTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            
            uc.Update(user.Id, null);
            user = uc.GetByLogin("testUser");
            
            user.Should().BeOfType<User>();
            user.Login.Should().Be("testUser");
            uc.Delete(user.Id);
        }
        
        [Fact]
        public void DeleteUserTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            
            uc.Delete(user.Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => uc.Get(user.Id));
        }
        
        [Fact]
        public void LoginTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");

            var loginSuccessful = uc.Login("testUser", "testUser");
            loginSuccessful.Should().BeTrue();
            
            uc.Delete(user.Id);
        }

        [Fact]
        public void GetUserRoleTest()
        {
            var uc = new UserController(true);
            uc.Add("testUser", "testUser", _roleId);
            var user = uc.GetByLogin("testUser");
            var role = user.Role;
            uc.Delete(user.Id);
        }
    }
}