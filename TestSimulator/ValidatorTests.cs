using Simulator;

namespace TestSimulator;
public class ValidatorTests
{
    #region Limiter Tests
    [Theory]
    [InlineData(5, 1, 10, 5)]     // Wartość w obrębie zakresu
    [InlineData(0, 1, 10, 1)]     // Wartość poniżej minimum
    [InlineData(15, 1, 10, 10)]   // Wartość powyżej maksimum
    [InlineData(-5, -10, -1, -5)] // Wartość poniżej minimum w zakresie ujemnym
    [InlineData(-15, -10, -1, -10)] // Wartość powyżej maksimum w zakresie ujemnym
    public void Limiter_ReturnsCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }
    #endregion

    #region Shortener Tests
    [Theory]
    [InlineData("hello", 5, 10, '-', "Hello")]      // Wartość w odpowiednim zakresie, tylko konwersja pierwszej litery
    [InlineData("hi", 5, 10, '-', "Hi---")]         // Zbyt krótka wartość, zostanie wydłużona
    [InlineData("this is a long string", 5, 10, '-', "This is a")] // Zbyt długa wartość, zostanie przycięta
    [InlineData("hi", 1, 5, '-', "Hi")]             // Krótsza niż minimalna, będzie wydłużona
    [InlineData("abc", 3, 3, '*', "Abc")]           // Idealna długość, tylko konwersja pierwszej litery
    [InlineData("a", 3, 5, '.', "A..")]             // Zbyt krótka, wydłużona
    [InlineData("", 5, 10, '.', ".....")]           // Pusty ciąg, zostanie wydłużony
    public void Shortener_ReturnsCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal(expected, result);
    }
    #endregion

    #region Edge Case Tests
    [Fact]
    public void Shortener_EmptyStringAndMinLength()
    {
        var result = Validator.Shortener("", 3, 5, '*');

        Assert.Equal("***", result); // Pusty ciąg powinien zostać wydłużony do 3 znaków
    }

    [Fact]
    public void Shortener_ExactLength()
    {
        var result = Validator.Shortener("Test", 4, 4, '_');

        Assert.Equal("Test", result); // Dokładnie 4 znaki, nic się nie zmienia
    }

    [Fact]
    public void Limiter_ZeroAndPositiveRange()
    {
        var result = Validator.Limiter(0, 0, 10);

        Assert.Equal(0, result); // Zero jest w obrębie zakresu
    }

    [Fact]
    public void Limiter_LargeNegativeValue()
    {
        var result = Validator.Limiter(-100, -50, -10);

        Assert.Equal(-50, result); // Wartość poniżej minimum
    }
    #endregion
}
