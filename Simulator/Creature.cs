namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

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

    public abstract void SayHi();

    public void Upgrade()
    {
        if (Level < 10)
        {
            level++;
        }
    }

    public void Go(Direction direction) => Console.WriteLine($"{Name} goes {direction}");

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
