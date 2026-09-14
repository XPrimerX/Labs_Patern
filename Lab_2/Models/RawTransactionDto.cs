using System.Globalization;

namespace Lab_2.Models;

public class RawTransactionDto
{
    public string? Id { get; set; }
    public string? Date { get; set; }
    public string? Amount { get; set; }
    public string? Description { get; set; }

    public bool IsValid =>
        !string.IsNullOrWhiteSpace(Id) &&
        DateTime.TryParse(Date, CultureInfo.InvariantCulture, DateTimeStyles.None, out _) &&
        decimal.TryParse(Amount, NumberStyles.Number, CultureInfo.InvariantCulture, out var amt) && amt > 0;
}