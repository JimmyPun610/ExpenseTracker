using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public interface IExpenseStorageService
{
    Task<IReadOnlyList<ExpenseRecord>> GetAllAsync();
    Task UpsertAsync(ExpenseRecord record);
    Task DeleteAllAsync();
    Task ImportAsync(IEnumerable<ExpenseRecord> records);
}
