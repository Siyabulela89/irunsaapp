using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EventType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventTypeId { get; set; }
        public string? EventTypeDescription { get; set; }

        //CrossCountry
        //Track&Field
        //RaceWalking
        //TrailRunning
        //RoadRunning
    }
}
