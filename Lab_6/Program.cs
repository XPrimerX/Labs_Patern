using System.Text;
using Lab_6.Abstraction;
using Lab_6.Commands;
using Lab_6.Decorator;
using Lab_6.Enums;
using Lab_6.Services;

namespace Lab_6;

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

        var elfSquad = decoratedClan.Where(u => u.Symbol == 'E').Select(u => new BattleUnit(u)).ToList();
        var dwarfSquad = decoratedClan.Where(u => u.Symbol == 'D').Select(u => new BattleUnit(u)).ToList();
        var gnomeSquad = decoratedClan.Where(u => u.Symbol == 'G').Select(u => new BattleUnit(u)).ToList();

        var allBattleUnits = elfSquad.Concat(dwarfSquad).Concat(gnomeSquad).ToList();

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

        var battleLeader = allBattleUnits.FirstOrDefault(b => ReferenceEquals(b.Unit, leader));

        var battleRenderer = new GraphicClanRenderer();
        var battleTextRenderer = new TextClanRenderer();

        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою — початковий стан");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        // Memento: створюємо контрольну точку ПЕРЕД боєм 
        var clanOriginator = new ClanOriginator(allBattleUnits);
        var checkpointManager = new CheckpointManager();

        Console.WriteLine();
        var checkpointBeforeBattle = clanOriginator.CreateCheckpoint("Перед боєм");
        checkpointManager.SaveCheckpoint(checkpointBeforeBattle);

        ClanLeader.Instance.Order(new ForwardCommand());
        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою після команди 'вперед'");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        Console.WriteLine();
        ClanLeader.Instance.Order(new FightCommand());
        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою після команди 'битися'");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        Console.WriteLine();
        ClanLeader.Instance.Order(new FightCommand());
        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою після повторної команди 'битися'");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        Console.WriteLine();
        ClanLeader.Instance.Order(new BackwardCommand());
        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою після команди 'назад'");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        Console.WriteLine();
        battleTextRenderer.RenderHeader("Підсумковий стан клану після бою (до відкату)");
        battleTextRenderer.RenderBattle(allBattleUnits, battleLeader);

        // Memento: відкат до контрольної точки "Перед боєм" 
        Console.WriteLine();
        var checkpoint = checkpointManager.Undo();
        if (checkpoint != null)
        {
            clanOriginator.RestoreCheckpoint(checkpoint);
        }

        Console.WriteLine();
        battleRenderer.RenderHeader("Дошка бою — після відновлення контрольної точки");
        battleRenderer.RenderBattle(allBattleUnits, battleLeader);

        Console.WriteLine();
        battleTextRenderer.RenderHeader("Підсумковий стан клану після відкату");
        battleTextRenderer.RenderBattle(allBattleUnits, battleLeader);
    }
}