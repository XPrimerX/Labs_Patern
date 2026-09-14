using Lab_1.Models;

namespace Lab_1.Interface;

public interface ITransactionParser
{
    List<RawTransactionDto> Parse(string content);
}