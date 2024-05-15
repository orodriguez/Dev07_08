using System.ComponentModel.DataAnnotations;

namespace Okane.Domain;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    //[Required] data annotation, indicating that it is a required field.
    [Required]
    public string Category { get; set; }
    // Add Descrition as optional ? Type String 
    public string? Description { get; set; }
}