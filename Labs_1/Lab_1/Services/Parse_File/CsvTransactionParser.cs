using Lab_1.Interface;
using Lab_1.Models;

namespace Lab_1.Services.Parse_File;

public class CsvTransactionParser: ITransactionParser
{
    public List<RawTransactionDto> Parse(string content)
    {
        var result = new List<RawTransactionDto>();
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines.Skip(1)) 
        {
            var parts = line.Trim().Split(';');
            if (parts.Length < 4) continue;

            result.Add(new RawTransactionDto
            {
                Id = parts[0],
                Date = parts[1],
                Amount = parts[2],
                Description = parts[3]
            });
        }
        return result;
    }
}