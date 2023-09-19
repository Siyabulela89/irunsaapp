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
        public int DashboardId { get; set; }
        public int DashboardEntiyId { get; set; }
        public bool LicenseStatus { get; set; }
        public int TransferDashboardId { get; set; }
        public int TransferDashboardEntiyId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
