﻿using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        int gameTurn = 1;
        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludlru";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        Console.WriteLine("SIMULATION!");
        Console.WriteLine("\nStarting positions:");
        mapVisualizer.Draw();
        while (simulation.Finished == false)
        {
            Console.WriteLine("Wciśnij dowolny przycisk by kontynuować...");
            Console.ReadKey();
            Console.WriteLine($"\nTura gry: {gameTurn}");
            Console.WriteLine($"{simulation.CurrentCreature} {simulation.CurrentCreature.position} idzie w kierunku {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
            gameTurn++;
        }
    }
}
