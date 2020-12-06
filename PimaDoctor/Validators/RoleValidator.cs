using System;
using System.Collections.Generic;
using PimaDoctor.Controllers;
using PimaDoctor.Models;

namespace PimaDoctor.Validators
{
    public class RoleValidator
    {
        private readonly bool _test;
        public RoleValidator(bool test = false)
        {
            _test = test;
        }

        public List<Role> GetAllRoles()
        {
            try
            {
                return new RoleController(_test).All();
            }
            catch (Exception e)
            {
                return new List<Role>();
            }
        }

        public Role GetRoleById(int id)
        {
            try
            {
                return new RoleController(_test).Get(id);
            }
            catch (Exception e)
            {
                return new Role();
            }
        }

        public Role GetRoleByName(string name)
        {
            try
            {
                return new RoleController(_test).GetByName(name);
            }
            catch (Exception e)
            {
                return new Role();
            }
        }

        public bool RoleAddValidation(string name)
        {
            try
            {
                new RoleController(_test).Add(name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RoleUpdateValidation(int id, string name)
        {
            try
            {
                new RoleController(_test).Update(id, name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RoleDeleteValidation(int id)
        {
            try
            {
                new RoleController(_test).Delete(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
