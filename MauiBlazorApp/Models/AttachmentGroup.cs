using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class AttachmentGroup
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentGroupId { get; set; }
        public string AttachmentGroupDescription { get; set; }  
        
        //Img
        //Doc


    }
}
