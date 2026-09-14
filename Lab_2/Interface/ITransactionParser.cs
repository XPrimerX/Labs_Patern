using Lab_2.Models;

namespace Lab_2.Interface;

public interface ITransactionParser
{
    List<RawTransactionDto> Parse(string content);
}
