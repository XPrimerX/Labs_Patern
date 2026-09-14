using Lab_2_2.Services;

namespace Lab_2_2;

class Program
{
    static void Main(string[] args)
    {
      
        var generator = new ClanGenerator();
        var clan = generator.GenerateClan();

        Console.WriteLine("=== Склад клану (текстовий вивід) ===");
        foreach (var unit in clan)
        {
            Console.WriteLine(unit);
        }


        var random = new Random();
        var leaderCandidate = clan[random.Next(clan.Count)];

        Console.WriteLine();


        var renderer = new ClanBoardRenderer();
        renderer.Render(clan, leaderCandidate);

        Console.WriteLine();
        Console.WriteLine("=== Глава клану ===");
        Console.WriteLine(leaderCandidate);
    }
}