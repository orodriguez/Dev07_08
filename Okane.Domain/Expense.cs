namespace Okane.Domain;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    //
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    public string? Description { get; set; }

    public string? InvoiceUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}