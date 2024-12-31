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

    public abstract string Greeting();

    public void Upgrade()
    {
        if (Level < 10)
        {
            level++;
        }
    }

    public string Go(Direction direction) => $"{Name} goes {direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions) =>
        directions.Select(direction => Go(direction)).ToArray();

    public string[] Go(string directions) =>
        Go(DirectionParser.Parse(directions));

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
