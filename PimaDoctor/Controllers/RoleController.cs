#nullable enable
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using PimaDoctor.Models;

namespace PimaDoctor.Controllers
{
    public static class RoleController
    {
        public static List<Role> All()
        {
            using var db = new DbCinema();
            var query = from role in db.Roles
                orderby role.Name descending
                select role;
            var roles = query.ToList();
            return roles;
        }

        public static Role Get(int id)
        {
            using var db = new DbCinema();
            var query = from role in db.Roles
                where role.Id == id
                select role;
            var singleRole = query.ToList()[0];
            return singleRole;
        }

        public static Role GetByName(string name)
        {
            using var db = new DbCinema();
            var query = from role in db.Roles
                where role.Name == name
                select role;
            var singleRole = query.ToList()[0];
            return singleRole;
        }

        public static void Add(string name)
        {
            using var db = new DbCinema();
            db.Roles
                .Value(role => role.Name, name)
                .Insert();
        }

        public static void Update(int id, string? name)
        {
            using var db = new DbCinema();
            var role = Get(id);

            if (name != null)
            {
                role.Name = name;
            }

            db.Update(role);
        }
        
        public static void Delete(int id)
        {
            using var db = new DbCinema();
            db.Roles
                .Where(role => role.Id == id)
                .Delete();
        }
    }
}