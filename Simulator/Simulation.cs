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
    public List<Creature> Creatures { get; }

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
    public Creature CurrentCreature {
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
            return Moves[currentMoveNameIndex].ToString();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
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
    public void Turn() {
        if (Finished)
            throw new InvalidOperationException("Symulacja dobiegła końca!");

        Creature creature = CurrentCreature;
        Direction direction = DirectionParser.Parse(Moves)[currentMoveNameIndex];

        try
        {
            creature.Go(direction);
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
}