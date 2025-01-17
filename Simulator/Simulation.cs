using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int currentCreatureIndex = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Symulacja dobiegła końca!");
            return Creatures[currentCreatureIndex];
        }
    }

    private int currentMoveNameIndex = 0;

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Symulacja dobiegła końca!");
            return DirectionParser.Parse(Moves[currentMoveNameIndex].ToString())[0].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Mapa jest pusta!");
        }

        if (positions.Count != creatures.Count)
        {
            throw new ArgumentException("Liczba pozycji musi być taka sama jak liczba stworów!");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].AddToMap(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Symulacja dobiegła końca!");

        IMappable creature = CurrentCreature;
        Direction direction = DirectionParser.Parse(Moves)[currentMoveNameIndex];
        if (creature.Position == null)
        {
            throw new InvalidOperationException("Pozycja stworzenia jest pusta.");
        }

        Point nextPosition = Map.Next(creature.Position.Value, direction);

        try
        {
            creature.Go(direction);

            var mapCell = Map.At(nextPosition);

            if (Map.At(nextPosition).Count > 1)
            {
                ResolveCombat(mapCell[0], mapCell[1]);
            }
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException(
                $"Wystąpił błąd przy próbie poruszenia postacią: {creature}. Szczegóły: {exception.Message}", exception);
        }

        currentMoveNameIndex++;
        if (currentMoveNameIndex >= Moves.Length)
        {
            Finished = true;
        }

        currentCreatureIndex++;
        if (currentCreatureIndex >= Creatures.Count)
        {
            currentCreatureIndex = 0;
        }
    }

    private void ResolveCombat(IMappable creature1, IMappable creature2)
    {
        int power1 = creature1.Power;
        int power2 = creature2.Power;

        if (power1 > power2)
        {
            if (creature2 is Orc)
            {
                ((Orc)creature2).winBattle();
                Console.WriteLine("Orc won");
            }
            else if (creature2 is Elf)
            {
                ((Elf)creature2).winBattle();
                Console.WriteLine("Elf won");
            }
        }
        else if (power1 < power2)
        {
            if (creature1 is Orc)
            {
                ((Orc)creature1).winBattle();
                Console.WriteLine("Orc won");
            }
            else if (creature1 is Elf)
            {
                ((Elf)creature1).winBattle();
                Console.WriteLine("Elf won");
            }
        }

        // If powers are equal, no change
    }
}
