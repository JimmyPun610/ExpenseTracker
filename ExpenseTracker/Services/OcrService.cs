using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace ExpenseTracker.Services;

public class OcrService(IJSRuntime jsRuntime) : IOcrService
{
    public async Task<ReceiptScanResult?> ScanAsync(IBrowserFile file)
    {
        using var stream = file.OpenReadStream(5 * 1024 * 1024);
        using var streamRef = new DotNetStreamReference(stream);
        return await jsRuntime.InvokeAsync<ReceiptScanResult?>("receiptOcr.scan", streamRef, file.Name);
    }
}
