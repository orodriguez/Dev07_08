namespace Okane.Domain;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public required string Category { get; set; }
    // Add Descrition as optional ? Type String 
    public string? Description { get; set; }
}