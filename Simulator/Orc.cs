namespace Simulator;
public class Orc : Creature
{
    private int rage = 1;
    private int huntCounter = 0;

    public int Rage
    {
        get => rage;
        init => rage = value < 0 ? 1 : value > 10 ? 10 : value;
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() { }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCounter++;

        if (huntCounter % 2 == 0 && rage<10)
        {
            rage++;
        }
    }

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );

    public override int Power => 7 * Level + 3 * Rage;
}
