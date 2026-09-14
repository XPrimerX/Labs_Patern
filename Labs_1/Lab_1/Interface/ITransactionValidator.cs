using Lab_1.Models;

namespace Lab_1.Interface;

public interface ITransactionValidator
{
    List<Transaction> Validate(List<Transaction> transactions, out List<string> errors);
}