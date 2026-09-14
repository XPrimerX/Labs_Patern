using Lab_2.Interface;
using Lab_2.Services;

namespace Lab_2.Services;

public class ImportProcessorBuilder
{
    private IDataReader? _dataReader;
    private ITransactionParser? _parser;
    private ITransactionValidator? _validator;
    private ITransactionRepository? _repository;
    private IProgressReporter? _progressReporter;

    public ImportProcessorBuilder WithDataReader(IDataReader reader)
    {
        _dataReader = reader;
        return this;
    }

    public ImportProcessorBuilder WithParser(ITransactionParser parser)
    {
        _parser = parser;
        return this;
    }

    public ImportProcessorBuilder WithValidator(ITransactionValidator validator)
    {
        _validator = validator;
        return this;
    }

    public ImportProcessorBuilder WithRepository(ITransactionRepository repository)
    {
        _repository = repository;
        return this;
    }

    public ImportProcessorBuilder WithProgressReporter(IProgressReporter reporter)
    {
        _progressReporter = reporter;
        return this;
    }

    public ImportProcessor Build()
    {
        if (_dataReader == null) throw new InvalidOperationException("IDataReader не встановлено");
        if (_parser == null) throw new InvalidOperationException("ITransactionParser не встановлено");
        if (_validator == null) throw new InvalidOperationException("ITransactionValidator не встановлено");
        if (_repository == null) throw new InvalidOperationException("ITransactionRepository не встановлено");
        if (_progressReporter == null) throw new InvalidOperationException("IProgressReporter не встановлено");

        return new ImportProcessor(_dataReader, _parser, _validator, _repository, _progressReporter);
    }
}