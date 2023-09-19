using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class PhotographerEntity
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotographerEntityId { get; set; }
        public string PhotographerName { get; set; }
        public string Avatar { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}
