using Simulator.Maps;

namespace Simulator;

public abstract class Creature
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
        position = startPosition;
        currentMap.Add(this, startPosition); // Dodaj stworzenie na mapę
    }

    public void Go(Direction direction)
    {
        if (currentMap == null || position == null)
        {
            throw new InvalidOperationException("Blad! - Stwor nie ma jeszcze przydzielonej mapy.");
        }

        var nextPosition = currentMap.Next(position.Value, direction);
        if (currentMap.Exist(nextPosition))
        {
            currentMap.Move(this, position.Value, nextPosition);
            position = nextPosition;
        }
    }
}
