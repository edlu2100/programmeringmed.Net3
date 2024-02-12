using System.ComponentModel.DataAnnotations;

namespace programmeringmed.Net3.Models;
public class PersonModel
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Förnamn är obligatorisk.")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Efternamn är obligatorisk.")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Ålder är obligatorisk.")]
    public int? Age { get; set; }
    [Required(ErrorMessage = "Email är obligatorisk.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Telefonnummer är obligatorisk.")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Adress är obligatorisk.")]
    public string? Address { get; set; }
    [Required(ErrorMessage = "Stad är obligatorisk.")]
    public string? City { get; set; }
    public List<BookModel>? Books { get; set; }
    public List<BorrowModel>? Borrows { get; set; }

}