using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class RoleType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleTypeId { get; set; }
        public string? RoleTypeDescription { get; set; }

        //SuperUser
        //Admin
        //Proxy
        //Owner
        //Minor
    }
}
