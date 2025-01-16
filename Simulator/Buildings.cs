using Simulator.Maps;

namespace Simulator;

public class Buildings : IMappable
{
    private string description = "Unknown";

    public int Level { get; set; }

    public int Power { get; private set; } = 1000;

    public Map? CurrentMap { get; private set; } = null;

    public Point? Position { get; private set; }

    protected void SetPosition(Point newPosition)
    {
        Position = newPosition;
    }

    public virtual char Symbol => 'W';
    public virtual string Info => $"{Description} <{Level}>";

    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 5, 30, '#');
    }

    public string Name => Description;

    public void AddToMap(Map map, Point startPosition)
    {
        CurrentMap = map;
        Position = startPosition;
        CurrentMap.Add(this, startPosition);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public virtual string Go(Direction direction)
    {
        //Building can't move
        return "";
    }
}
