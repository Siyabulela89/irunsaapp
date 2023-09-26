using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ClubEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubEntityId { get; set; }
        public string ClubName { get; set; }
        public string ClubRegistrationNumber { get; set; }
        //public string AssociatedProvinces { get; set; } //See lookup list
        public int ClubStatusId { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
