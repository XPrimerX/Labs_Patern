using System.Configuration;
using System.Text;
using System.Windows;
using Lab_2.BD;
using Lab_2.Factory;
using Lab_2.Interface;
using Lab_2.Services;
using Lab_2.Services.Parse_File;


namespace Lab_2;


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

        var parserResolver = new ParserResolver(new List<ITransactionParserFactory>
        {
            new CsvParserFactory(),
            new JsonParserFactory(),
            new XmlParserFactory()
        });

        var viewModel = new MainViewModel(
            parserResolver, dataReader, validator, repository, progressReporter, summaryWriter);

        var window = new MainWindow { DataContext = viewModel };
        window.Show();
    }
}