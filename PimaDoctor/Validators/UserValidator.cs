using System;
using System.Collections.Generic;
using PimaDoctor.Controllers;
using PimaDoctor.Models;

namespace PimaDoctor.Validators
{
    public class UserValidator
    {
        private readonly bool _test;
        public UserValidator(bool test = false)
        {
            _test = test;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return new UserController(_test).All();
            }
            catch (Exception e)
            {
                return new List<User>();
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return new UserController(_test).Get(id);
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                return new UserController(_test).GetByLogin(login);
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public bool UserAddValidation(string login, string password, int roleId = 3)
        {
            try
            {
                new RoleController(_test).Get(roleId);
                new UserController(_test).Add(login, password, roleId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UserUpdateValidation(int id, string? password, int roleId)
        {
            try
            {
                new RoleController(_test).Get(roleId);
                new UserController(_test).Update(id, password, roleId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UserDeleteValidation(int id)
        {
            try
            {
                new UserController(_test).Get(id);
                new UserController(_test).Delete(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UserLoginValidation(string login, string password)
        {
            try
            {
                return new UserController(_test).Login(login, password);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
