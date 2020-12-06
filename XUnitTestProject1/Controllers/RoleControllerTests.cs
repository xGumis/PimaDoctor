using System;
using System.Collections.Generic;
using FluentAssertions;
using PimaDoctor.Controllers;
using PimaDoctor.Models;
using Xunit;

namespace XUnitTestProject1.Controllers
{
    public class RoleControllerTests
    {
        [Fact]
        public void GetRoleTest()
        {
            var rc = new RoleController(true);
            rc.Add("testRole");
            var role = rc.GetByName("testRole");
            role.Should().BeOfType<Role>();
            rc.Delete(role.Id);
        }

        [Fact]
        public void GetAllRolesTest()
        {
            var rc = new RoleController(true);
            var roles = rc.All();
            roles.Should().BeOfType<List<Role>>();
        }

        [Fact]
        public void GetRoleByNameTest()
        {
            var rc = new RoleController(true);
            rc.Add("testRole");
            var role = rc.GetByName("testRole");
            role.Should().BeOfType<Role>();
            rc.Delete(role.Id);
        }

        [Fact]
        public void UpdateRole()
        {
            var rc = new RoleController(true);
            rc.Add("testRole");
            var role = rc.GetByName("testRole");
            
            rc.Update(role.Id, "updatedRole");
            role = rc.GetByName("updatedRole");
            
            role.Should().BeOfType<Role>();
            role.Name.Should().Be("updatedRole");
            rc.Delete(role.Id);
        }
        
        [Fact]
        public void UpdateRoleNullName()
        {
            var rc = new RoleController(true);
            rc.Add("testRole");
            var role = rc.GetByName("testRole");
            
            rc.Update(role.Id, null);
            role = rc.GetByName("testRole");
            
            role.Should().BeOfType<Role>();
            role.Name.Should().Be("testRole");
            rc.Delete(role.Id);
        }
        
        [Fact]
        public void DeleteRole()
        {
            var rc = new RoleController(true);
            rc.Add("testRole");
            var role = rc.GetByName("testRole");
            
            rc.Delete(role.Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => rc.Get(role.Id));
        }
    }
}