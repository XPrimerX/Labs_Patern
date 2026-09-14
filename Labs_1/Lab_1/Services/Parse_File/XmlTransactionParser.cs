using System.Xml.Linq;
using Lab_1.Interface;
using Lab_1.Models;

namespace Lab_1.Services.Parse_File;

public class XmlTransactionParser: ITransactionParser
{
    public List<RawTransactionDto> Parse(string content)
    {
        var doc = XDocument.Parse(content);
        return doc.Descendants("Transaction").Select(t => new RawTransactionDto
        {
            Id = t.Element("Id")?.Value,
            Date = t.Element("Date")?.Value,
            Amount = t.Element("Amount")?.Value,
            Description = t.Element("Description")?.Value
        }).ToList();
    }
}