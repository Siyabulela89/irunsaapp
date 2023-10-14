﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace irunsaapp.Models
{
    public class ContactDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailId { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactDescription { get; set; }
    }
}
