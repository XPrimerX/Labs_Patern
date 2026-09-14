using System.Text;
using Lab_4.Abstraction;
using Lab_4.Decorator;
using Lab_4.Enums;
using Lab_4.Services;


namespace Lab_4;

class Program
{
    private static IUnit UnwrapUnit(IUnit unit)
    {
        var current = unit;
        while (current is UnitDecorator decorator)
        {
            current = decorator.GetInner();
        }
        return current;
    }
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

     
        var elfSquad = decoratedClan.Where(u => u.Symbol == 'E').ToList();
        var dwarfSquad = decoratedClan.Where(u => u.Symbol == 'D').ToList();
        var gnomeSquad = decoratedClan.Where(u => u.Symbol == 'G').ToList();

        var mediator = new ClanMediator();

        var elfHandler = new SquadHandler("Ельфи", elfSquad, mediator);
        var dwarfHandler = new SquadHandler("Воїн", dwarfSquad, mediator);
        var gnomeHandler = new SquadHandler("Гноми", gnomeSquad, mediator);

     
        elfHandler.SetNext(dwarfHandler).SetNext(gnomeHandler);
        mediator.SetChain(elfHandler);

        
        ClanLeader.Instance.SetMediator(mediator);
        ClanLeader.Instance.Elect((Units)UnwrapUnit(leader));

        Console.WriteLine();
        ClanLeader.Instance.PrintInfo();


        ClanLeader.Instance.Order(Commands_Leader.forward);
        Console.WriteLine();
        new ClanReport(new GraphicClanRenderer()).Show("Дошка після команди 'вперед'", decoratedClan, leader);
        Console.WriteLine();
        ClanLeader.Instance.Order(Commands_Leader.fight);
        
        ClanLeader.Instance.Order(Commands_Leader.backward);
        Console.WriteLine();
        new ClanReport(new GraphicClanRenderer()).Show("Дошка після команди 'назад'", decoratedClan, leader);
    }

  
    
}