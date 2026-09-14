using System.IO;
using Lab_1.Interface;

namespace Lab_1.Services;

public class FileReader:IDataReader
{
    public string Read(string source)
    {
        if (!File.Exists(source))
            throw new FileNotFoundException($"Файл не знайдено: {source}", source);

        using var reader = new StreamReader(source);
        return reader.ReadToEnd();
    }
}