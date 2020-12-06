using System.Collections.Generic;
using FluentAssertions;
using PimaDoctor.Models;
using PimaDoctor.Validators;
using Xunit;

namespace XUnitTestProject1.Validators
{
    public class RoleValidatorTests
    {
        [Fact]
        public void ListTest()
        {
            var roles = RoleValidator.GetAllRoles();
            roles.Should().BeOfType<List<Role>>();
        }

        [Fact]
        public void GetRoleByIdTest()
        {
            RoleValidator.RoleAddValidation("testRole");
            var roleId = RoleValidator.GetRoleByName("testRole").Id;
            var role = RoleValidator.GetRoleById(roleId);
            role.Should().BeOfType<Role>();
            RoleValidator.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void GetRoleByNameTest()
        {
            RoleValidator.RoleAddValidation("testRole");
            var role = RoleValidator.GetRoleByName("testRole");
            role.Should().BeOfType<Role>();
            RoleValidator.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleAddValidationTest()
        {
            var success = RoleValidator.RoleAddValidation("testRole");
            success.Should().BeTrue();
            var role = RoleValidator.GetRoleByName("testRole");
            RoleValidator.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleUpdateValidationTest()
        {
            RoleValidator.RoleAddValidation("testRole");
            var role = RoleValidator.GetRoleByName("testRole");
            var success = RoleValidator.RoleUpdateValidation(role.Id, "updatedRole");
            success.Should().BeTrue();
            RoleValidator.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleDeleteValidationTest()
        {
            RoleValidator.RoleAddValidation("testRole");
            var role = RoleValidator.GetRoleByName("testRole");
            var success = RoleValidator.RoleDeleteValidation(role.Id);
            success.Should().BeTrue();
        }
    }
}