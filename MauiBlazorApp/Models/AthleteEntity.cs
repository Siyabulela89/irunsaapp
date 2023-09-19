using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class AthleteEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AthleteEntityId { get; set; }
        public string ID_Passport { get; set; }
        public int NationalityID { get; set; }
        public int GenderId { get; set; }
        public DateTime? DOB { get; set; }
        public int? ClubEntityId { get; set; }
        public string Email { get; set; }
        public string AthleteName { get; set; }
        public string Avatar { get; set; }
        public string AthleteSurname { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}
