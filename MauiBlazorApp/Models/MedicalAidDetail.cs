using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class MedicalAidDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicalAidDetailId { get; set; }
        public int EntityTypeID { get; set; }
        public int EntiyId { get; set; }
        public int MedicalAidId { get; set; }
        public int Dependants { get; set; }
        public DateTime JoinedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
