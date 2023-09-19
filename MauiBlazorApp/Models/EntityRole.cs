using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class EntityRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityRoleId { get; set; }
        public string RoleTypeId { get; set; }
        public int EntiyId { get; set; }
        public bool HasAccess { get; set; }
    }
}
