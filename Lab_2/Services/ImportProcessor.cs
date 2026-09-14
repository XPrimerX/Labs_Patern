using System.Globalization;
using Lab_2.Interface;
using Lab_2.Models;

namespace Lab_2.Services;

public class ImportProcessor
{
    private readonly IDataReader _dataReader;
    private readonly ITransactionParser _parser;
    private readonly ITransactionValidator _validator;
    private readonly ITransactionRepository _repository;
    private readonly IProgressReporter _progressReporter;

    public ImportProcessor(
        IDataReader dataReader,
        ITransactionParser parser,
        ITransactionValidator validator,
        ITransactionRepository repository,
        IProgressReporter progressReporter)
    {
        _dataReader = dataReader;
        _parser = parser;
        _validator = validator;
        _repository = repository;
        _progressReporter = progressReporter;
    }

    public ImportResult Import(string source)
    {
        Singleton_Logger.Instance.Log($"Імпорт розпочато: {source}");
        _progressReporter.ReportProgress(0);

        var content = _dataReader.Read(source);
        _progressReporter.ReportProgress(25);
        Singleton_Logger.Instance.Log("Файл прочитано");
        var rawData = _parser.Parse(content);
        _progressReporter.ReportProgress(50);

        var transactions = rawData
            .Where(x => x.IsValid)
            .Select(x => new Transaction
            {
                Id = x.Id!,
                Date = DateTime.Parse(x.Date!, CultureInfo.InvariantCulture),
                Amount = decimal.Parse(x.Amount!, NumberStyles.Number, CultureInfo.InvariantCulture),
                Description = x.Description
            }).ToList();
        _progressReporter.ReportProgress(75);

        var validTransactions = _validator.Validate(transactions, out var errors);
        _repository.Save(validTransactions);
        _progressReporter.ReportProgress(100);
        Singleton_Logger.Instance.Log($"Імпорт завершено: {validTransactions.Count} успішних");
        return new ImportResult
        {
            TotalCount = rawData.Count,
            SuccessCount = validTransactions.Count,
            FailedCount = rawData.Count - validTransactions.Count,
            Errors = errors
        };
    }
}