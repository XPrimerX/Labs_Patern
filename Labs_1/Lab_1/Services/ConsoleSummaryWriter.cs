using Lab_1.Interface;
using Lab_1.Models;

namespace Lab_1.Services;

public class ConsoleSummaryWriter : IImportSummaryWriter
{
    public void WriteSummary(ImportResult result)
    {
        Console.WriteLine("=== Підсумковий звіт по імпорту ===");
        Console.WriteLine($"Всього оброблено: {result.TotalCount}");
        Console.WriteLine($"Успішно: {result.SuccessCount}");
        Console.WriteLine($"Помилок: {result.FailedCount}");

        if (result.Errors.Any())
        {
            Console.WriteLine("Деталі помилок:");
            foreach (var error in result.Errors)
                Console.WriteLine($" - {error}");
        }
    }
}