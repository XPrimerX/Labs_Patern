using Lab_1.Models;

namespace Lab_1.Interface;

public interface IImportSummaryWriter
{
    void WriteSummary(ImportResult result);
}