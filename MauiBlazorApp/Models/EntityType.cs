using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EntityType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityTypeId { get; set; }
        public string? EntityTypeDescription { get; set; }

        //Athlete
        //Club
        //Event
        //Coach
        //Province
        //Photographer
    }
}
