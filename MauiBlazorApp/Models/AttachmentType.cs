using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class AttachmentType
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentTypeId { get; set; }
        public string AttachmentTypeDescription { get; set; }     

        //Avatar
        //ProofOfResidence
        //PhotographerPic

    }
}
