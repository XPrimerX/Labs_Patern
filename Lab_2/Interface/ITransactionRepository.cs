using Lab_2.Models;

namespace Lab_2.Interface;

public interface ITransactionRepository
{
    void Save(List<Transaction> transactions);
    IEnumerable<Transaction> GetAll();
    Transaction? GetById(string id);
    void Delete(string id);
}