using System.Text;
using Lab_3_2.Decorator;
using Lab_3_2.Services;

namespace Lab_3_2;


class Program
{
    static void Main(string[] args)
    {
      
        Console.OutputEncoding = Encoding.UTF8;

        var generator = new ClanGenerator();
        var clan = generator.GenerateClan();

        var decoratedClan = UnitDecorationService.ApplyRandomDecorations(clan);

        var random = new Random();
        var leader = decoratedClan[random.Next(decoratedClan.Count)];
        
        var textReport = new DetailedClanReport(new TextClanRenderer());
        textReport.Show("Склад клану (текстовий вивід)", decoratedClan, leader);

        Console.WriteLine();

        var graphicReport = new ClanReport(new GraphicClanRenderer());
        graphicReport.Show("Розташування загонів на фронті", decoratedClan, leader);
    }
}