using System.ComponentModel.DataAnnotations;

namespace programmeringmed.Net3.Models;
public class AuthorModel
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Förnamn är obligatorisk.")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Efternamn är obligatorisk.")]
    public string? LastName { get; set; }

    public List<BookModel>? Books { get; set; }


}