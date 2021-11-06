using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contact.API.Models
{
    public class ContactModel
    {
        public Guid ContactId { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string Firma { get; set; }
        [Required]
        public ContactDetailModel ContactDetail { get; set; }
    }
}
