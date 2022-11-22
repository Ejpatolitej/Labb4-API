using System.ComponentModel.DataAnnotations;

namespace Labb4_API.Models
{
    public class Website
    {
        [Key]
        public int WebsiteID { get; set; }
        public string WebpageLink { get; set; }

        public int InterestID { get; set; }
        public Interest? Interest { get; set; }
        public int PersonID { get; set; }
        public Person? Person { get; set; }
    }
}
