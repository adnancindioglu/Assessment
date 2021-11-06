using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contact.API.Models
{
    public class ContactDetailModel
    {
        public Guid ContactDetailId { get; set; }

        [Required]
        public int ContactDetailType { get; set; }

        [Required]
        public string ContactDetailDescription { get; set; }
    }
}
