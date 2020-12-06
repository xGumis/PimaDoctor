using System;
using System.Collections.Generic;
using PimaDoctor.Controllers;
using PimaDoctor.Models;

namespace PimaDoctor.Validators
{
    public static class RoleValidator
    {

        public static List<Role> GetAllRoles()
        {
            try
            {
                return new RoleController().All();
            }
            catch (Exception e)
            {
                return new List<Role>();
            }
        }

        public static Role GetRoleById(int id)
        {
            try
            {
                return new RoleController().Get(id);
            }
            catch (Exception e)
            {
                return new Role();
            }
        }

        public static Role GetRoleByName(string name)
        {
            try
            {
                return new RoleController().GetByName(name);
            }
            catch (Exception e)
            {
                return new Role();
            }
        }

        public static bool RoleAddValidation(string name)
        {
            try
            {
                new RoleController().Add(name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool RoleUpdateValidation(int id, string name)
        {
            try
            {
                new RoleController().Update(id, name);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool RoleDeleteValidation(int id)
        {
            try
            {
                new RoleController().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
