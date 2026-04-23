namespace ExpenseTracker.Models;

public static class ExpenseCategories
{
    public const string Food = "Food";
    public const string Transport = "Transport";
    public const string Shopping = "Shopping";
    public const string Bills = "Bills";
    public const string Health = "Health";
    public const string Entertainment = "Entertainment";
    public const string Other = "Other";

    public static readonly IReadOnlyList<string> Defaults =
    [
        Food,
        Transport,
        Shopping,
        Bills,
        Health,
        Entertainment,
        Other
    ];
}
