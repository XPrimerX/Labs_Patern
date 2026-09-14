using System.Text.Json;
using Lab_2.Factory;
using Lab_2.Interface;
using Lab_2.Models;

namespace Lab_2.Services.Parse_File;

public class JsonTransactionParser: ITransactionParser
{
    public List<RawTransactionDto> Parse(string content)
    {
        var dtos = JsonSerializer.Deserialize<List<RawTransactionDto>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return dtos ?? new List<RawTransactionDto>();
    }
}