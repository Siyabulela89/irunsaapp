using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace irunsaapp.Models
{
    public class Club
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }
        public string ClubDescription { get; set; }

        //public override string ToString()
        //{
        //    return $"{ClubId} - {ClubDescription}";
        //}


    }
}
