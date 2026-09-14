using Lab_2.Models;

namespace Lab_2.Interface;

public interface ITransactionValidator
{
    List<Transaction> Validate(List<Transaction> transactions, out List<string> errors);
}