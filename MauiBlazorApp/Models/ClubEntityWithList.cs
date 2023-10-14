using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ClubEntityWithList
    {
        public ClubEntity clubEntity { get; set; }
        public List<string> associatedProvinces { get; set; }
        public List<ContactValue> contactDetails { get; set; }
    }
}
