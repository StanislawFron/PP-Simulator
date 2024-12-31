using Simulator;

namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_CreatesRectangleWithCorrectCoordinates()
    {
        var rectangle = new Rectangle(2, 3, 5, 6);

        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_ThrowsArgumentExceptionForCollinearPoints()
    {
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(2, 3, 2, 6));

        Assert.Equal("Prostokąt nie może być 'chudy' (punkty współliniowe).", exception.Message);
    }

    [Fact]
    public void Constructor_SwapsPointsToEnsureCorrectOrder()
    {
        var rectangle = new Rectangle(5, 6, 2, 3);

        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_CreatesRectangleFromTwoPoints()
    {
        var p1 = new Point(2, 3);
        var p2 = new Point(5, 6);
        var rectangle = new Rectangle(p1, p2);

        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Theory]
    [InlineData(3, 4, true)]   // Punkt wewnątrz prostokąta
    [InlineData(1, 2, false)]  // Punkt na lewo od prostokąta
    [InlineData(6, 7, false)]  // Punkt na prawo od prostokąta
    [InlineData(2, 3, true)]   // Punkt na dolnym lewym rogu prostokąta
    [InlineData(5, 6, true)]   // Punkt na górnym prawym rogu prostokąta
    public void Contains_ReturnsCorrectResult(int x, int y, bool expected)
    {
        var rectangle = new Rectangle(2, 3, 5, 6);
        var point = new Point(x, y);
        var result = rectangle.Contains(point);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectStringRepresentation()
    {
        var rectangle = new Rectangle(2, 3, 5, 6);
        var result = rectangle.ToString();

        Assert.Equal("(2, 3):(5, 6)", result);
    }

    // Przypadek brzegowy: testowanie prostokąta o minimalnych wymiarach
    [Fact]
    public void Constructor_ThrowsArgumentExceptionForSinglePointRectangle()
    {
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(2, 3, 2, 3));

        Assert.Equal("Prostokąt nie może być 'chudy' (punkty współliniowe).", exception.Message);
    }

    // Przypadek brzegowy: prostokąt o dużych współrzędnych
    [Fact]
    public void Constructor_CreatesLargeRectangle()
    {
        var rectangle = new Rectangle(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue);

        Assert.Equal(int.MinValue, rectangle.X1);
        Assert.Equal(int.MinValue, rectangle.Y1);
        Assert.Equal(int.MaxValue, rectangle.X2);
        Assert.Equal(int.MaxValue, rectangle.Y2);
    }
}
