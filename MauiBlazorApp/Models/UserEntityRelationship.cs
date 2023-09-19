using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class UserEntityRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEntityRelationshipId { get; set; }
        public int UserId { get; set; }
        public int EntityTypeID { get; set; }
        public int EntiyId { get; set; }
        public int RoleTypeId { get; set; }//Relationship
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
