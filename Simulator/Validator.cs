namespace Simulator;
public static class Validator
{
    public static int Limiter(int value, int min, int max) {
        return value < min ? min : value > max ? max : value; 
    }

    public static string Shortener(string value, int min, int max, char placeholder){
        var trimmedValue = value.Trim();

        if (trimmedValue.Length < min)
        {
            for (int i = trimmedValue.Length; i < min; i++)
            {
                trimmedValue += placeholder;
            }
        }

        if (trimmedValue.Length > max)
        {
            trimmedValue = trimmedValue.Substring(0, max);
        }

        trimmedValue = trimmedValue.Trim();

        if (trimmedValue.Length < min)
        {
            for (int i = trimmedValue.Length; i < min; i++)
            {
                trimmedValue += placeholder;
            }
        }

        if (char.IsLower(trimmedValue[0]))
        {
            trimmedValue = char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1);
        }

        return trimmedValue;
    }
}
