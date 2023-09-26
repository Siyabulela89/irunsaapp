using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ClubStatus
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubStatusId { get; set; }
        public string ClubStatusDescription { get; set; }
      
        //Listed
        //Claimed/Active
        //Disabled
        //Suspended

    }
}
