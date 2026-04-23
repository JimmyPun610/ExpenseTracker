namespace ExpenseTracker.Services;

public class ReceiptScanResult
{
    public string? FileName { get; set; }
    public string? DataUrl { get; set; }
    public decimal? Amount { get; set; }
    public string? Category { get; set; }
    public string? Text { get; set; }
}
