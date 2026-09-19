using System.ComponentModel.DataAnnotations;

namespace Smart_Event_Managment_System.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        [StringLength(99)]
        public string Name { get; set; }

        [Required]
        [StringLength(199)]
        public string Location { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Capacity { get; set; }
        //vanue has many events
        public ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
