using System;
using System.ComponentModel.DataAnnotations;

namespace Notebook.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int PersonId { get; set; }

        [Required]
        [StringLength(10)]
        public string phoneNumber { get; set; } = string.Empty;
    }
}
