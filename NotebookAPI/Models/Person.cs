using System.ComponentModel.DataAnnotations;

namespace Notebook.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(30)]
        public string? LastName { get; set; }

        public int BirthYear { get; set; }
        public virtual ICollection<Phone>? Phones { get; set; }
    }
}