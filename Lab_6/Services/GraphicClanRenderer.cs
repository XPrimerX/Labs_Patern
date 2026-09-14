
using Lab_6.Abstraction;

namespace Lab_6.Services;

public class GraphicClanRenderer : IClanRenderer
{
    private readonly int _width;
    private readonly int _height;

    public GraphicClanRenderer(int width = 20, int height = 20)
    {
        _width = width;
        _height = height;
    }

    public void RenderHeader(string title) => Console.WriteLine($"=== {title} ===");

    public void RenderClan(List<IUnit> clan, IUnit? leader)
    {
        var board = BuildEmptyBoard();

        foreach (var unit in clan)
        {
            if (InBounds(unit.X, unit.Y))
                board[unit.Y, unit.X] = ReferenceEquals(unit, leader) ? 'L' : unit.Symbol;
        }

        Print(board);
        Console.WriteLine("Позначення: E - Ельф, D - Гном-карлик (Dwarf), G - Гном (Gnome), L - Глава клану");
    }

    public void RenderBattle(List<BattleUnit> clan, BattleUnit? leader)
    {
        var board = BuildEmptyBoard();

        foreach (var unit in clan)
        {
            if (!InBounds(unit.Unit.X, unit.Unit.Y)) continue;

            char symbol;
            if (ReferenceEquals(unit, leader))
                symbol = 'L';
            else
                symbol = GetSymbolByState(unit);

            board[unit.Unit.Y, unit.Unit.X] = symbol;
        }

        Print(board);
        Console.WriteLine("Позначення: Велика літера - здоровий, маленька - поранений, x - вийшов з бою, L - Глава клану");
    }

    private char GetSymbolByState(BattleUnit unit)
    {
        char baseSymbol = unit.Unit.Symbol;

        return unit.StateName switch
        {
            "Здоровий" => baseSymbol,                    // E, D, G
            "Поранений" => char.ToLower(baseSymbol),      // e, d, g
            "Вийшов з бою" => 'x',
            _ => '?'
        };
    }

    private char[,] BuildEmptyBoard()
    {
        var board = new char[_height, _width];
        for (int y = 0; y < _height; y++)
            for (int x = 0; x < _width; x++)
                board[y, x] = '.';
        return board;
    }

    private bool InBounds(int x, int y) => x >= 0 && x < _width && y >= 0 && y < _height;

    private void Print(char[,] board)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
                Console.Write(board[y, x] + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}