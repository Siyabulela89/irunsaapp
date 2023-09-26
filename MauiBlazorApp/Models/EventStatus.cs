using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EventStatus
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventStatusId { get; set; }
        public string EventStatusDescription { get; set; }
      
        //Captured
        //Active
        //Disabled
        //Cancelled

    }
}
