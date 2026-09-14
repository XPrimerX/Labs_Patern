using System.Text;
using System.Windows;
using Lab_1.BD;
using Lab_1.Interface;
using Lab_1.Services;
using Lab_1.Services.Parse_File;


namespace Lab_1;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        Console.OutputEncoding = Encoding.UTF8;
        base.OnStartup(e);

        var dbContext = new AppDbContext("app.db");
        dbContext.Database.EnsureCreated();

        IDataReader dataReader = new FileReader();
        ITransactionValidator validator = new TransactionValidator();
        TransactionBD repository = new TransactionBD(dbContext);
        var progressReporter = new ViewModelProgressReporter();
        IImportSummaryWriter summaryWriter = new ConsoleSummaryWriter();

        var parserResolver = new ParserResolver(new Dictionary<string, ITransactionParser>
        {
            [".csv"] = new CsvTransactionParser(),
            [".json"] = new JsonTransactionParser(),
            [".xml"] = new XmlTransactionParser()
        });

        var viewModel = new MainViewModel(
            parserResolver, dataReader, validator, repository, progressReporter, summaryWriter);

        var window = new MainWindow { DataContext = viewModel };
        window.Show();
    }
}