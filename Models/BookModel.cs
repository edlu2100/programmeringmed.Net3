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
        public int? ReleaseYear { get; set; } // Utgivningsår
                [Required(ErrorMessage = "Antal böcker är obligatoriskt.")]
        public int Quantity { get; set; }
        public List<BorrowModel>? Borrows { get; set; }
    
}
