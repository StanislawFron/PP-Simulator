using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";

    public int Power { get; private set; } = 0;
    public uint Size { get; set; } = 3;
    public Map? currentMap { get; private set; } = null;

    public Point? Position { get; private set; }

    protected void SetPosition(Point newPosition)
    {
        Position = newPosition;
    }
    public virtual char Symbol => 'A';
    public virtual string Info => $"{Description} <{Size}>";

    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }

    public string Name => Description;

    public void AddToMap(Map map, Point startPosition)
    {
        currentMap = map;
        Position = startPosition;
        currentMap.Add(this, startPosition);
    }
    public virtual string Go(Direction direction)
    {
        if (currentMap != null)
        {
            var newPos = currentMap.Next(Position.Value, direction);
            currentMap.Move(this, Position.Value, newPos);
            Position = newPos;
            return direction.ToString().ToLower();
        }
        else
        {
            throw new InvalidOperationException("Blad! - Zwierze nie ma jeszcze przydzielonej mapy.");
        }
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
