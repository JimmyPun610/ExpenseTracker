using Microsoft.AspNetCore.Components.Forms;

namespace ExpenseTracker.Services;

public interface IOcrService
{
    Task<ReceiptScanResult?> ScanAsync(IBrowserFile file);
}
