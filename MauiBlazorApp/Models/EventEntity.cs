using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EventEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventEntityId { get; set; }
        public string EventDescription { get; set; }
        public string Avatar { get; set; }
        public bool EventStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
