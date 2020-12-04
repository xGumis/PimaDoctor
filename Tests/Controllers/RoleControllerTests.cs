using System;
using FluentAssertions;
using System.Collections.Generic;
using NUnit.Framework;
using PimaDoctor.Controllers;
using PimaDoctor.Models;

namespace Tests.Controllers
{
    [TestFixture]
    public class RoleControllerTests
    {
        [Test]
        public void GetRoleTest()
        {
            var role = RoleController.Get(1);
            role.Should().BeOfType<Role>();
        }

        [Test]
        public void GetAllRolesTest()
        {
            var roles = RoleController.All();
            roles.Should().BeOfType<List<Role>>();
        }

        [Test]
        public void GetRoleByNameTest()
        {
            var role = RoleController.GetByName("admin");
            role.Should().BeOfType<Role>();
        }

        [Test]
        public void GetRole()
        {
            RoleController.Add("testRole");
            var role = RoleController.GetByName("testRole");
            role.Should().BeOfType<Role>();
            RoleController.Delete(role.Id);
        }

        [Test]
        public void UpdateRole()
        {
            RoleController.Add("testRole");
            var role = RoleController.GetByName("testRole");
            
            RoleController.Update(role.Id, "updatedRole");
            role = RoleController.GetByName("updatedRole");
            
            role.Should().BeOfType<Role>();
            role.Name.Should().Be("updatedRole");
            RoleController.Delete(role.Id);
        }

        [Test]
        public void UpdateRoleNullName()
        {
            RoleController.Add("testRole");
            var role = RoleController.GetByName("testRole");
            
            RoleController.Update(role.Id, null);
            role = RoleController.GetByName("testRole");
            
            role.Should().BeOfType<Role>();
            role.Name.Should().Be("testRole");
            RoleController.Delete(role.Id);
        }

        [Test]
        public void DeleteRole()
        {
            RoleController.Add("testRole");
            var role = RoleController.GetByName("testRole");
            
            RoleController.Delete(role.Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => RoleController.Get(role.Id));
        }
    }
}