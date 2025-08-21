using Humanizer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProsperDaily.Shared.Entities;

public class Transaction : Entity
{
    public string Name { get; set; } = default!;
    public decimal Amount { get; set; }
    public bool IsIncome { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;

    [NotMapped]
    public string AmountText => $"{(IsIncome ? "+ " : "- ")}{Amount:C}";
    [NotMapped]
    public string AmountColor => IsIncome ? Color.DarkGreen.ToHex() : Color.DarkRed.ToHex();
    [NotMapped]
    public string TransactionDateString => TransactionDate.Humanize();
}
