using System.Text.Json;
using Lab_1.Interface;
using Lab_1.Models;

namespace Lab_1.Services.Parse_File;

public class JsonTransactionParser: ITransactionParser
{
    public List<RawTransactionDto> Parse(string content)
    {
        var dtos = JsonSerializer.Deserialize<List<RawTransactionDto>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return dtos ?? new List<RawTransactionDto>();
    }
}