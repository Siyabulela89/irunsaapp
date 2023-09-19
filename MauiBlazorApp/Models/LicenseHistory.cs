using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class LicenseHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LicenseHistoryId { get; set; }
        public int LicenseTypeId { get; set; }
        public int LicenseCode { get; set; }
        public int Year { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityTypeEntiyId { get; set; }
        public bool LicenseStatus { get; set; }
        public int TransferEntityTypeId { get; set; }
        public int TransferEntityTypeEntiyId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
