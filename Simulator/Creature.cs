namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

    public abstract int Power { get; }
    public string Name
    {
        get => name;
        init
        {
            var trimmedValue = value.Trim();

            if (trimmedValue.Length < 3)
            {
                for (int i = trimmedValue.Length; i < 3; i++)
                {
                    trimmedValue += "#";
                }
            }

            if (trimmedValue.Length > 25)
            {
                trimmedValue = trimmedValue.Substring(0, 25);
            }

            trimmedValue = trimmedValue.Trim();

            if (trimmedValue.Length < 3)
            {
                for (int i = trimmedValue.Length; i < 3; i++)
                {
                    trimmedValue += "#";
                }
            }

            if (char.IsLower(trimmedValue[0]))
            {
                trimmedValue = char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1);
            }

            name = trimmedValue;
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init 
        {
            if (value < 1)
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
            else
            {
                level = value;
            }
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public string Info => $"{Name} [{Level}]";

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
}
