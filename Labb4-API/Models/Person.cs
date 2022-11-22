using System.ComponentModel.DataAnnotations;

namespace Labb4_API.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<Interest>? Interests { get; set; }
    }
}
