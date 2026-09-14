using Lab_4.Abstraction;

namespace Lab_4.Services;

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
        var board = new char[_height, _width];
        for (int y = 0; y < _height; y++)
        for (int x = 0; x < _width; x++)
            board[y, x] = '.';

        foreach (var unit in clan)
        {
            if (unit.X >= 0 && unit.X < _width && unit.Y >= 0 && unit.Y < _height)
                board[unit.Y, unit.X] = ReferenceEquals(unit, leader) ? 'L' : unit.Symbol;
        }

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
                Console.Write(board[y, x] + " ");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Позначення: E - Ельф, D - Гном-карлик (Dwarf), G - Гном (Gnome), L - Глава клану");
    }
}