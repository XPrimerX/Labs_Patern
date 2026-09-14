using System.Xml.Linq;
using Lab_2.Factory;
using Lab_2.Interface;
using Lab_2.Models;

namespace Lab_2.Services.Parse_File;

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