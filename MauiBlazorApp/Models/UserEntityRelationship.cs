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
        public int EntiyId { get; set; }
        public string RoleTypeId { get; set; }//Relationship
        public string CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
