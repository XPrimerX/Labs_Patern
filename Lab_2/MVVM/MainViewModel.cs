using System.IO;
using System.Windows.Input;
using Lab_2.BD;
using Lab_2.Interface;
using Lab_2.Models;
using Lab_2.Services;
using Microsoft.Win32;



public class MainViewModel : ViewModelBase
{
    private readonly ParserResolver _parserResolver;
    private readonly IDataReader _dataReader;
    private readonly ITransactionValidator _validator;
    private readonly TransactionBD _repository;
    private readonly ViewModelProgressReporter _progressReporter;
    private readonly IImportSummaryWriter _summaryWriter;

    private string? _selectedFilePath;
    public string? SelectedFilePath
    {
        get => _selectedFilePath;
        set => SetProperty(ref _selectedFilePath, value);
    }

    private int _progress;
    public int Progress
    {
        get => _progress;
        set => SetProperty(ref _progress, value);
    }

    private string _statusMessage = "Готово до імпорту";
    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public ICommand SelectFileCommand { get; }
    public ICommand RunImportCommand { get; }

    public MainViewModel(
        ParserResolver parserResolver,
        IDataReader dataReader,
        ITransactionValidator validator,
        TransactionBD repository,
        ViewModelProgressReporter progressReporter,
        IImportSummaryWriter summaryWriter)
    {
        _parserResolver = parserResolver;
        _dataReader = dataReader;
        _validator = validator;
        _repository = repository;
        _progressReporter = progressReporter;
        _summaryWriter = summaryWriter;

        _progressReporter.ProgressChanged += p => Progress = p;

        SelectFileCommand = new RelayCommand(SelectFile);
        RunImportCommand = new RelayCommand(RunImport, () => !string.IsNullOrEmpty(SelectedFilePath));
    }

    private void SelectFile()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Data files (*.csv;*.json;*.xml)|*.csv;*.json;*.xml"
        };
        if (dialog.ShowDialog() == true)
        {
            SelectedFilePath = dialog.FileName;
        }
    }

    private void RunImport()
    {
        if (string.IsNullOrEmpty(SelectedFilePath))
        {
            StatusMessage = "Файл не обрано";
            return;
        }

        try
        {
            var extension = Path.GetExtension(SelectedFilePath);
            var parser = _parserResolver.Resolve(extension);

            var processor = new ImportProcessorBuilder()
                .WithDataReader(_dataReader)
                .WithParser(parser)
                .WithValidator(_validator)
                .WithRepository(_repository)
                .WithProgressReporter(_progressReporter)
                .Build();

            Progress = 0;
            StatusMessage = "Імпорт виконується...";

            var result = processor.Import(SelectedFilePath);

            _summaryWriter.WriteSummary(result);
            StatusMessage = $"Готово: {result.SuccessCount} успішно, {result.FailedCount} з помилками";
        }
        catch (Exception e)
        {
            StatusMessage = $"Помилка: {e.Message}";
        }
    }
}