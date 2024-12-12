﻿namespace Simulator;
public class Elf : Creature
{
    private int agility = 1;
    private int singCounter = 0;

    public int Agility
    {
        get => agility;
        init => agility = value < 0 ? 1 : value > 10 ? 10 : value;
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;

        if (singCounter % 3 == 0 && agility<10)
        {
            agility++;
        }
    }

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );

    public override int Power => 8 * Level + 2 * Agility;
}
