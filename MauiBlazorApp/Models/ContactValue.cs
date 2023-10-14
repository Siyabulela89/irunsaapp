using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ContactValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactTypeId { get; set; }
        public string ContactTypeDescription { get; set; }
        public string ContactDescription { get; set; }
    }
}
