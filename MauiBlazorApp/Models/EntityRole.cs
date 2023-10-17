using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EntityRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityRoleId { get; set; }
        public int RoleTypeId { get; set; }
        public int EntityId { get; set; }
        public bool HasAccess { get; set; }
    }
}
