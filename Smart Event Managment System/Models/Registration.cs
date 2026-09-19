using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Smart_Event_Managment_System.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(29)]
        public string Status { get; set; }
        //regi has one event
        [JsonIgnore]
        public Event ?Event { get; set; }
        public int EventId {  get; set; }
        //rgi has ine att
        public int AttendeeId { get; set; }
        public Attendee ?Attendee { get; set; }

    }
}
