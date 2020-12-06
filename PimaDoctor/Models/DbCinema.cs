using LinqToDB;
using LinqToDB.Data;

namespace PimaDoctor.Models
{
    /*
     * Model that allows connecting to DB and operating on it
     */
    public class DbCinema : LinqToDB.Data.DataConnection
    {
        public DbCinema() : base("PrimaDoctor") { }
        public ITable<Role> Roles => GetTable<Role>();
        public ITable<User> Users => GetTable<User>();
    }
}