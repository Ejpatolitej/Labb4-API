using System.ComponentModel.DataAnnotations;

namespace Labb4_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        public string InterestTitle { get; set; }
        public string InterestDescript { get; set; }

        public int? PersonID { get; set; }
        public Person? Person { get; set; }

        public ICollection<Website>? Websites { get; set; }
    }
}
