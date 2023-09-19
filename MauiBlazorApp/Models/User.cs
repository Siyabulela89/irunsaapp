using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdType { get; set; }
        public string Id { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AcceptTandC { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
