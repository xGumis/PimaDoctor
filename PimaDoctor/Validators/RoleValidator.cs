using System;
using System.Collections.Generic;
using PimaDoctor.Controllers.Controllers;
using PimaDoctor.Models;

namespace PimaDoctor.Validators
{
    public static class RoleValidator
    {

        public static List<Role> GetAllRoles()
        {
            try
            {
                return RoleController.All();
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
                return RoleController.Get(id);
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
                return RoleController.GetByName(name);
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
                if (name == null || GetRoleByName(name).Name != null)
                {
                    return false;
                }
                RoleController.Add(name);
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
                RoleController.Update(id, name);
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
                RoleController.Delete(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
