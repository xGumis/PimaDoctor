using System;
using System.Collections.Generic;
using PimaDoctor.Controllers;
using PimaDoctor.Models;

namespace PimaDoctor.Validators
{
    public static class UserValidator
    {

        public static List<User> GetAllUsers()
        {
            try
            {
                return UserController.All();
            }
            catch (Exception e)
            {
                return new List<User>();
            }
        }

        public static User GetUserById(int id)
        {
            try
            {
                return UserController.Get(id);
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public static User GetUserByLogin(string login)
        {
            try
            {
                return UserController.GetByLogin(login);
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public static bool UserAddValidation(string login, string password, int roleId = 3)
        {
            try
            {
                UserController.Add(login, password, roleId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UserUpdateValidation(int id, string password, int roleId)
        {
            try
            {
                UserController.Update(id, password, roleId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UserDeleteValidation(int id)
        {
            try
            {
                UserController.Delete(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UserLoginValidation(string login, string password)
        {
            try
            {
                return UserController.Login(login, password);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
