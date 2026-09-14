using Lab_2_2.Abstraction;

namespace Lab_2_2.Services;

public class ClanBoardRenderer
{
    private readonly int _width;
    private readonly int _height;

    public ClanBoardRenderer(int width = 20, int height = 20)
    {
        _width = width;
        _height = height;
    }

    public void Render(List<Units> clan, Units? leader = null)
    {
        var board = new char[_height, _width];

  
        for (int y = 0; y < _height; y++)
        for (int x = 0; x < _width; x++)
            board[y, x] = '.';

   
        foreach (var unit in clan)
        {
            int x = unit.moves.X;
            int y = unit.moves.Y;

            if (x >= 0 && x < _width && y >= 0 && y < _height)
            {
                if (unit == leader)
                {
                    board[y, x] = 'L';
                }
                else
                {
                    board[y, x] = GetSymbol(unit);
                }
            }
        }

        Console.WriteLine("=== Розташування загонів на фронті ===");
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Console.Write(board[y, x] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Позначення: E - Ельф, D - Гном-карлик (Dwarf), G - Гном (Gnome), L - Глава клану");
    }

    private char GetSymbol(Units unit) => unit.GetType().Name switch
    {
        "Elf" => 'E',
        "Warrior" => 'W',
        "Gnome" => 'G',
        "Dwarf" => 'D',
        _ => '?'
    };
}