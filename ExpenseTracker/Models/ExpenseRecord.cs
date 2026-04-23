namespace ExpenseTracker.Models;

public class ExpenseRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public string Category { get; set; } = ExpenseCategories.Other;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
    public string? ReceiptFileName { get; set; }
    public string? ReceiptDataUrl { get; set; }
}
