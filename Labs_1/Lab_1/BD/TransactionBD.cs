using System.Linq;
using Lab_1.Interface;
using Lab_1.Models;

namespace Lab_1.BD;

public class TransactionBD:ITransactionRepository
{
    private readonly AppDbContext _context;
    public TransactionBD(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public void Save(List<Transaction> transactions)
    {
        if (transactions.Count == 0) return;

        var existingIds = _context.Transactions
            .Select(t => t.Id)
            .ToHashSet();

        var newTransactions = transactions
            .Where(t => !existingIds.Contains(t.Id))
            .ToList();

        if (newTransactions.Count == 0) return;

        _context.Transactions.AddRange(newTransactions);
        _context.SaveChanges();
    }

    public IEnumerable<Transaction> GetAll()
    {
        return _context.Transactions.ToList();
    }

    public Transaction? GetById(string id)
    {
        return _context.Transactions.Find(id);
    }

    public void Update(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var entity = _context.Transactions.Find(id);
        if (entity is null) return;

        _context.Transactions.Remove(entity);
        _context.SaveChanges();
    }
}