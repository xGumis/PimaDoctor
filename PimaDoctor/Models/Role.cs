using LinqToDB.Mapping;

namespace PimaDoctor.Models
{
    /*
     * Constructor created automatically by LinqToDB
     * Creating custom constructor generates an error
     * when fetching data from DB
     */
    [Table(Name = "roles")]
    public class Role
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column(Name = "name"), NotNull]
        public string Name { get; set; }
    }
}