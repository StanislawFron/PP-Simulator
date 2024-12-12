namespace Simulator;
public class Animals
{
    private string description = "Unknown";
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
     
    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
