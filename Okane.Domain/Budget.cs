namespace Okane.Domain;

public class Budget
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int Maximum { get; set; }
    public Category Category { get; set; } = null!;
}