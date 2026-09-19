using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Event_Managment_System.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(99)]
        public string Title { get; set; }

        [Required]
        [StringLength(499)]
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(49)]
        public string Category { get; set; }

        [Required]
        [Range(1,10000)]
        public int Capacity { get; set; }
        //event has one organizer
        [ForeignKey(nameof(Organizer))]
        public int OrganizerId { get; set; }
        public Organizer ?Organizer { get; set; }

        //event has one vanue
        [ForeignKey(nameof(Venue))]
        public int VenueId { get; set; }
        public Venue ?Venue { get; set; }
        //event has many regi
        public ICollection<Registration> Registries { get; set; }= new List<Registration>();
    }
}
