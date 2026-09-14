using Lab_1.Models;

namespace Lab_1.Interface;

public interface ITransactionRepository
{
    void Save(List<Transaction> transactions);
    IEnumerable<Transaction> GetAll();
    Transaction? GetById(string id);
    void Delete(string id);
}