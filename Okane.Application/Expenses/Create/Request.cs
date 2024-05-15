namespace Okane.Application.Expenses.Create;

// Heres our record of inmutables Amount and category 
// Add Description as String? !
public record Request(int Amount, string Category, string? Description);