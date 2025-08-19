namespace ProsperDaily.Shared.Entities;

public class Transaction : Entity
{
    public string Name { get; set; } = default!;
    public decimal Amount { get; set; }
    public bool IsIncome { get; set; }
    public DateTime OperationDate { get; set; }
}
