using System.Text.Json;
using ExpenseTracker.Models;
using Microsoft.JSInterop;

namespace ExpenseTracker.Services;

public class ExpenseStorageService(IJSRuntime jsRuntime) : IExpenseStorageService
{
    private const string StorageKey = "expense-tracker-records";

    public async Task<IReadOnlyList<ExpenseRecord>> GetAllAsync()
    {
        var json = await jsRuntime.InvokeAsync<string?>("expenseStore.get", StorageKey);
        if (string.IsNullOrWhiteSpace(json))
        {
            return [];
        }

        var records = JsonSerializer.Deserialize<List<ExpenseRecord>>(json);
        return records ?? [];
    }

    public async Task UpsertAsync(ExpenseRecord record)
    {
        var records = (await GetAllAsync()).ToList();
        var index = records.FindIndex(r => r.Id == record.Id);

        if (index >= 0)
        {
            records[index] = record;
        }
        else
        {
            records.Add(record);
        }

        var payload = JsonSerializer.Serialize(records);
        await jsRuntime.InvokeVoidAsync("expenseStore.set", StorageKey, payload);
    }
}
