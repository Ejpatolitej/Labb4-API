using System.ComponentModel.DataAnnotations;

namespace Labb4_API.Models
{
    public class Website
    {
        [Key]
        public int WebsiteID { get; set; }
        public string WebpageLink { get; set; }

        public int? InterestID { get; set; }
        public Interest? Interests { get; set; }
        public int? PersonID { get; set; }
        public Person? Persons { get; set; }
    }
}
