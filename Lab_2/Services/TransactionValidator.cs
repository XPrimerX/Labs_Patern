using Lab_2.Interface;
using Lab_2.Models;

namespace Lab_2.Services;

public class TransactionValidator: ITransactionValidator
{
    private readonly List<Func<Transaction, bool>> _rules = new()
    {
        t => t.Amount > 0,
        t => !string.IsNullOrWhiteSpace(t.Id),
        t => t.Date != default
    };

    public List<Transaction> Validate(List<Transaction> transactions, out List<string> errors)
    {
        errors = new List<string>();
        var valid = new List<Transaction>();
        foreach (var t in transactions)
        {
            if (_rules.All(rule => rule(t))) valid.Add(t);
            else errors.Add($"Транзакція {t.Id} не пройшла перевірку");
        }
        return valid;
    }
}