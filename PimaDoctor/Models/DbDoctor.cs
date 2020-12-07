using LinqToDB;
using LinqToDB.Data;

namespace PimaDoctor.Models
{
    /*
     * Model that allows connecting to DB and operating on it
     */
    public class DbDoctor : LinqToDB.Data.DataConnection
    {
        public DbDoctor() : base("PrimaDoctor") { }
        public ITable<Role> Roles => GetTable<Role>();
        public ITable<User> Users => GetTable<User>();
    }
}