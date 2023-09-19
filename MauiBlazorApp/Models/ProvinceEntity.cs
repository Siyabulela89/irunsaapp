using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ProvinceEntity
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvinceEntityId { get; set; }
        public string ProvinceName { get; set; }

        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}
