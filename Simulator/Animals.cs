namespace Simulator;
public class Animals
{
    private string description = "Unknown";
    public uint Size { get; set; } = 3;
    public string Info => $"{Description} <{Size}>";
     
    public string Description
    {
        get => description;
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

            if (trimmedValue.Length > 15)
            {
                trimmedValue = trimmedValue.Substring(0, 15);
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

            description = trimmedValue;
        }
    }
}
