using System.ComponentModel.DataAnnotations;

namespace programmeringmed.Net3.Models
{
    public class BorrowModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Titel är obligatorisk.")]
        public int? BookId { get; set; }
        public BookModel? Books { get; set; }

        [Required(ErrorMessage = "Namn på personen är obligatorisk.")]
        public int? PersonId { get; set; }
        public PersonModel? Persons { get; set; }

        [Required(ErrorMessage = "Datum för lånet är obligatorisk.")]
        [Display(Name = "Datum för lån")]
        public DateTime BorrowDate { get; set; }

        public BorrowModel()
        {
            BorrowDate = DateTime.Now; // Sätt BorrowDate till aktuell tid när objektet skapas
        }
    }


}
