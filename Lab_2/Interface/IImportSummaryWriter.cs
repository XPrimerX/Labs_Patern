using Lab_2.Models;

namespace Lab_2.Interface;

public interface IImportSummaryWriter
{
    void WriteSummary(ImportResult result);
}