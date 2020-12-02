using LinqToDB.Mapping;

namespace PimaDoctor.Models
{
    /*
     * Constructor created automatically by LinqToDB
     * Creating custom constructor generates an error
     * when fetching data from DB
     */
    [Table(Name = "users")]
    public class User
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column(Name = "login"), NotNull]
        public string Login { get; set; }
        
        [Column(Name = "password"), NotNull]
        public string Password { get; set; }
        
        [Column(Name = "role"), NotNull]
        public int RoleId { get; set; }
        
        public Role Role { get; set; }
        
        /*
         * Builder for user, used while fetching
         * the role from different table
         */
        public static User Build(User user, Role role)
        {
            if (user != null)
            {
                user.Role = role;
            }
            return user;
        }
    }
}