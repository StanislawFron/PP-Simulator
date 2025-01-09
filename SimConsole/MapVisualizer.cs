using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Point orcPos = new Point(-1, -1);
        Point elfPos = new Point(-1, -1);
        Point groupPos = new Point(-1, -1);
        for (int x = 0; x < _map.SizeX; x++)
        {
            for (int y = 0; y < _map.SizeX; y++)
            {
                if (_map.At(x, y).Count != 0)
                {
                    if (_map.At(x, y).Count == 1 && _map.At(x, y)[0].ToString().StartsWith("O"))
                    {
                        orcPos = new Point(x, y);
                    }
                    if (_map.At(x, y).Count == 1 && _map.At(x, y)[0].ToString().StartsWith("E"))
                    {
                        elfPos = new Point(x, y);
                    }
                    if (_map.At(x, y).Count > 1)
                    {
                        groupPos = new Point(x, y);
                    }
                }
            }
        }
        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");
        for (int row = 0; row < _map.SizeY; row++)
        {
            Console.Write(Box.Vertical);
            for (int col = 0; col < _map.SizeX; col++)
            {
                if (row == orcPos.Y && col == orcPos.X)
                    Console.Write($"O{Box.Vertical}");
                else if (row == elfPos.Y && col == elfPos.X)
                    Console.Write($"E{Box.Vertical}");
                else if (row == groupPos.Y && col == groupPos.X)
                    Console.Write($"X{Box.Vertical}");
                else
                    Console.Write($" {Box.Vertical}");
            }
            Console.WriteLine();
            if (row < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int col = 0; col < _map.SizeX - 1; col++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }
        Console.Write(Box.BottomLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}