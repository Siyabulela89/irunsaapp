using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ProvinceEntityRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvinceEntityRelationshipId { get; set; }
        public int ProvinceId { get; set; }
        public int EntityTypeID { get; set; }
        public int EntityId { get; set; }

    }
}
