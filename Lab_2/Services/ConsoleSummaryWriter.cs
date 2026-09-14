using Lab_2.Interface;
using Lab_2.Models;

namespace Lab_2.Services;

public class ConsoleSummaryWriter : IImportSummaryWriter
{
    public void WriteSummary(ImportResult result)
    {
        Singleton_Logger.Instance.Log("=== Підсумковий звіт по імпорту ===");
        Singleton_Logger.Instance.Log($"Всього оброблено: {result.TotalCount}");
        Singleton_Logger.Instance.Log($"Успішно: {result.SuccessCount}");
        Singleton_Logger.Instance.Log($"Помилок: {result.FailedCount}");

        if (result.Errors.Any())
        {
            Singleton_Logger.Instance.Log("Деталі помилок:");
            foreach (var error in result.Errors)
                Singleton_Logger.Instance.Log($" - {error}");
        }
    }
}