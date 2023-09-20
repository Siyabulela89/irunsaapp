using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace irunsaapp.Models
{
    public class ClubList
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubListId { get; set; }
        public string Club { get; set; }

        public override string ToString()
        {
            return $"{ClubListId} - {Club}";
        }


    }
}
