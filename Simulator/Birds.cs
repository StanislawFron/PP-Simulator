namespace Simulator;

public class Birds : Animals
{
    public bool CanFly = true;
    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
}