using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PimaDoctor.Controllers;
using PimaDoctor.Models;
using PimaDoctor.Validators;
using Xunit;

namespace XUnitTestProject1.Validators
{
    public class UserValidatorTests
    {
        private readonly int _roleId;
        private readonly UserValidator _uv = new UserValidator(true);

        
        public UserValidatorTests()
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
        public void ListTest()
        {
            
            var roles = _uv.GetAllUsers();
            roles.Should().BeOfType<List<User>>();
        }

        [Fact]
        public void GetUserByIdTest()
        {
            _uv.UserAddValidation("testUser", "testUser", _roleId);
            var roleId = _uv.GetUserByLogin("testUser").Id;
            var user = _uv.GetUserById(roleId);
            user.Should().BeOfType<User>();
            _uv.UserDeleteValidation(user.Id);
        }

        [Fact]
        public void GetUserByNameTest()
        {
            _uv.UserAddValidation("testUser", "testUser", _roleId);
            var user = _uv.GetUserByLogin("testUser");
            user.Should().BeOfType<User>();
            _uv.UserDeleteValidation(user.Id);
        }

        [Fact]
        public void UserAddValidationTest()
        {
            var success = _uv.UserAddValidation("testUser", "testUser", _roleId);
            success.Should().BeTrue();
            var user = _uv.GetUserByLogin("testUser");
            _uv.UserDeleteValidation(user.Id);
        }

        [Fact]
        public void UserUpdateValidationTest()
        {
            _uv.UserAddValidation("testUser", "testUser", _roleId);
            var user = _uv.GetUserByLogin("testUser");
            var success = _uv.UserUpdateValidation(user.Id, null, _roleId);
            success.Should().BeTrue();
            _uv.UserDeleteValidation(user.Id);
        }

        [Fact]
        public void UserDeleteValidationTest()
        {
            _uv.UserAddValidation("testUser", "testUser", _roleId);
            var user = _uv.GetUserByLogin("testUser");
            var success = _uv.UserDeleteValidation(user.Id);
            success.Should().BeTrue();
        }

        [Fact]
        public void UserLoginValidationTest()
        {
            _uv.UserAddValidation("testUser", "testUser", _roleId);
            var user = _uv.GetUserByLogin("testUser");
            var success = _uv.UserLoginValidation("testUser", "testUser");
            success.Should().BeTrue();
            _uv.UserDeleteValidation(user.Id);
        }
        
        [Fact]
        public void FailedGetUserByIdTest()
        {
            var user = _uv.GetUserById(-1);
            user.Should().BeOfType<User>();
            user.Id.Should().Be(0);
        }

        [Fact]
        public void FailedGetUserByLoginTest()
        {
            var user = _uv.GetUserByLogin("this user should not exist");
            user.Should().BeOfType<User>();
            user.Id.Should().Be(0);
        }

        [Fact]
        public void FailedUserUpdateValidationTest()
        {
            var success = _uv.UserUpdateValidation(-1, "test", _roleId);
            success.Should().BeFalse();
        }
        
        [Fact]
        public void FailedUserDeleteValidationTest()
        {
            var userId = _uv.GetAllUsers().Last().Id + 1;
            var success = _uv.UserDeleteValidation(userId);
            success.Should().BeFalse();
        }

        [Fact]
        public void FailedUserLoginValidationTest()
        {
            var success = _uv.UserLoginValidation("this user should not exist", "test");
            success.Should().BeFalse();
        }
        
        [Fact]
        public void FailedUserAddValidationTest()
        {
            var success = _uv.UserAddValidation("testUser", "testUser", -1);
            success.Should().BeFalse();

        }
    }
}