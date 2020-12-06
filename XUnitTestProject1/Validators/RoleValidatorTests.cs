﻿using System.Collections.Generic;
using FluentAssertions;
using PimaDoctor.Models;
using PimaDoctor.Validators;
using Xunit;

namespace XUnitTestProject1.Validators
{
    public class RoleValidatorTests
    {
        private readonly RoleValidator _rv = new RoleValidator(true);
        
        [Fact]
        public void ListTest()
        {
            var roles = _rv.GetAllRoles();
            roles.Should().BeOfType<List<Role>>();
        }

        [Fact]
        public void GetRoleByIdTest()
        {
            _rv.RoleAddValidation("testRole");
            var roleId = _rv.GetRoleByName("testRole").Id;
            var role = _rv.GetRoleById(roleId);
            role.Should().BeOfType<Role>();
            _rv.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void GetRoleByNameTest()
        {
            _rv.RoleAddValidation("testRole");
            var role = _rv.GetRoleByName("testRole");
            role.Should().BeOfType<Role>();
            _rv.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleAddValidationTest()
        {
            var success = _rv.RoleAddValidation("testRole");
            success.Should().BeTrue();
            var role = _rv.GetRoleByName("testRole");
            _rv.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleUpdateValidationTest()
        {
            _rv.RoleAddValidation("testRole");
            var role = _rv.GetRoleByName("testRole");
            var success = _rv.RoleUpdateValidation(role.Id, "updatedRole");
            success.Should().BeTrue();
            _rv.RoleDeleteValidation(role.Id);
        }

        [Fact]
        public void RoleDeleteValidationTest()
        {
            _rv.RoleAddValidation("testRole");
            var role = _rv.GetRoleByName("testRole");
            var success = _rv.RoleDeleteValidation(role.Id);
            success.Should().BeTrue();
        }
    }
}