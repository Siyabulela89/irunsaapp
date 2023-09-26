using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class Attachment
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentId { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int AttachmentGroupId { get; set; }
        public int AttachmentTypeId { get; set; }
        public int AttachmentUrl { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }




    }
}
