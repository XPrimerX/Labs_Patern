namespace Lab_2.Models;

public class Transaction
{
    public string Id { get; set; } = default!;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}