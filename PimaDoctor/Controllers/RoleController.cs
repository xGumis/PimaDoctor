#nullable enable
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using NUnit.Framework.Constraints;
using PimaDoctor.Models;

namespace PimaDoctor.Controllers
{
    public class RoleController
    {
        private readonly bool _test;
        public RoleController(bool test = false)
        {
            _test = test;
        }
        
        public List<Role> All()
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            var query = from role in db.Roles
                orderby role.Name descending
                select role;
            var roles = query.ToList();
            return roles;
        }

        public Role Get(int id)
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            var query = from role in db.Roles
                where role.Id == id
                select role;
            var singleRole = query.ToList()[0];
            return singleRole;
        }

        public Role GetByName(string name)
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            var query = from role in db.Roles
                where role.Name == name
                select role;
            var singleRole = query.ToList()[0];
            return singleRole;
        }

        public void Add(string name)
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            db.Roles
                .Value(role => role.Name, name)
                .Insert();
        }

        public void Update(int id, string? name)
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            var role = Get(id);

            if (name != null)
            {
                role.Name = name;
            }

            db.Update(role);
        }
        
        public void Delete(int id)
        {
            DataConnection.DefaultSettings = new MySettings(_test);

            using var db = new DbCinema();
            db.Roles
                .Where(role => role.Id == id)
                .Delete();
        }
    }
}