using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description cannot be null ...")]
        [StringLength(255)]
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}