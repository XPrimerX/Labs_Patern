using System;
using System.IO;
using System.Linq;
using Lab_1.BD;
using Lab_1.Models;
using Microsoft.Data.Sqlite;
using Xunit;

namespace Test;

public class BD_Test : IDisposable
{
    private readonly string _dbPath;
    private readonly AppDbContext _context;
    private readonly TransactionBD _repository;

    public BD_Test()
    {
        _dbPath = $"test_{Guid.NewGuid()}.db";
        _context = new AppDbContext(_dbPath);
        _context.Database.EnsureCreated();
        _repository = new TransactionBD(_context);
    }

    [Fact]
    public void Add_SavesTransaction_ToDatabase()
    {
        var transaction = new Transaction
        {
            Id = "1",
            Date = DateTime.Now,
            Amount = 100.50m,
            Description = "Test"
        };

        _repository.Add(transaction);
        
        var result = _repository.GetById("1");
        Assert.NotNull(result);
        Assert.Equal(100.50m, result!.Amount);
    }

    [Fact]
    public void GetAll_ReturnsAllSavedTransactions()
    {
        _repository.Add(new Transaction { Id = "1", Date = DateTime.Now, Amount = 10 });
        _repository.Add(new Transaction { Id = "2", Date = DateTime.Now, Amount = 20 });

        var result = _repository.GetAll();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetById_ReturnsNull_WhenNotFound()
    {
        var result = _repository.GetById("не_існує");

        Assert.Null(result);
    }

    [Fact]
    public void Update_ChangesTransactionData()
    {
        var transaction = new Transaction { Id = "1", Date = DateTime.Now, Amount = 10 };
        _repository.Add(transaction);

        transaction.Amount = 999;
        _repository.Update(transaction);

        var result = _repository.GetById("1");
        Assert.Equal(999, result!.Amount);
    }

    [Fact]
    public void Delete_RemovesTransaction()
    {
        _repository.Add(new Transaction { Id = "1", Date = DateTime.Now, Amount = 10 });

        _repository.Delete("1");

        var result = _repository.GetById("1");
        Assert.Null(result);
    }

    public void Dispose()
    {
        _context.Dispose();
        SqliteConnection.ClearAllPools();

        if (File.Exists(_dbPath))
            File.Delete(_dbPath);
    }
}