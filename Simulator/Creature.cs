using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string name = "Unknown";
    private Map? currentMap;
    private Point? position;

    public abstract int Power { get; }
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');

    }

    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Info { get; }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (Level < 10)
        {
            level++;
        }
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void AddToMap(Map map, Point startPosition)
    {
        currentMap = map;
        Position = startPosition;
        currentMap.Add(this, startPosition);
    }

    public void Go(Direction direction)
    {
        if (currentMap == null || Position == null)
        {
            throw new InvalidOperationException("Blad! - Stwor nie ma jeszcze przydzielonej mapy.");
        }

        var nextPosition = currentMap.Next(Position.Value, direction);
        if (currentMap.Exist(nextPosition))
        {
            currentMap.Move(this, Position.Value, nextPosition);
            Position = nextPosition; // Aktualizacja przez właściwość.
        }
    }

    // Implementacja właściwości Position z interfejsu IMappable.
    public Point? Position
    {
        get => position;
        private set => position = value;
    }
}
