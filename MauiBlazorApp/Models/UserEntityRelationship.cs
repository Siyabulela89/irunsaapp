using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class UserEntityRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEntityRelationshipId { get; set; }
        public string UserId { get; set; }
        public int EntityTypeID { get; set; }
        public int EntityId { get; set; }
        public int RoleTypeId { get; set; }//Relationship
        public string UpdatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
