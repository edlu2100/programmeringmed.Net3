using System.ComponentModel.DataAnnotations;

namespace programmeringmed.Net3.Models;

public class BookModel
{
       public int Id { get; set; }
        [Required(ErrorMessage = "Titeln är obligatorisk.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Kategorin är obligatorisk.")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Författare är obligatorisk.")]
        public int? AuthorId { get; set; }
        public AuthorModel? Author { get; set; }
        [Required(ErrorMessage = "Utgivningsår är obligatorisk.")]
        [Display(Name = "Utgivningsår")]
        public int? ReleaseYear { get; set; } // Utgivningsår
        public List<BorrowModel>? Borrows { get; set; }
    
}
