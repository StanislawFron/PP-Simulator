namespace Simulator;

public class Tower : Buildings
{
    public override string Go(Direction direction)
    {
        Level++;
        return "";
    }

    public override string ToString() => $"{base.ToString()}";
}
