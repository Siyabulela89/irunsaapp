using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class MedicalAidDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicalAidDetailId { get; set; }
        public string MedicalAidDetailDescription { get; set; }
        public int Dependants { get; set; }
    }
}
