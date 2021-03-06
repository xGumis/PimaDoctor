﻿using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using PimaDoctor.Models;
using PimaDoctor.Utilities;

namespace PimaDoctor.Controllers
{
    public class UserController
    {
        private readonly bool _test;
        public UserController(bool test = false)
        {
            _test = test;
        }
        
        public List<User> All()
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            var query = from user in db.Users
                orderby user.Login descending
                select user;
            var users = query.ToList();
            return users;
        }
        
        public User Get(int id)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            var queryable = from user in db.Users
                where user.Id == id
                join role in db.Roles on user.RoleId equals role.Id
                select User.Build(user, role);

            var singleUser = queryable.ToList()[0];
            return singleUser;
        }

        public User GetByLogin(string login)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            var queryable = from user in db.Users
                            where user.Login == login
                            join role in db.Roles on user.RoleId equals role.Id
                            select User.Build(user, role);

            var singleUser = queryable.ToList()[0];
            return singleUser;
        }

        /*
         * Default role is user
         * 1 - admin
         * 2 - doctor
         * 3 - patient
         */
        public void Add(string login, string password, int roleId = 3)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            db.Users
                .Value(user => user.Login, login)
                .Value(user => user.Password, RSAEncryption.Encrypt(password))
                .Value(user => user.RoleId, roleId)
                .Insert();
        }

        public void Update(int id, string? password = null, int? roleId = null)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            var user = Get(id);

            if (password != null)
            {
                user.Password = RSAEncryption.Encrypt(password);
            }
            
            if (roleId != null)
            {
                user.RoleId = (int) roleId;
            }

            db.Update(user);
        }
        
        public void Delete(int id)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            db.Users
                .Where(user => user.Id == id)
                .Delete();
        }

        public bool Login(string login, string password)
        {
            DataConnection.DefaultSettings = new MySettings(_test);
            
            using var db = new DbDoctor();
            var user = GetByLogin(login);

            if (user != null && password == RSAEncryption.Decrypt(user.Password))
            {
                return true;
            }

            return false;
        }
    }
}