using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_CreatesPointWithCorrectCoordinates()
    {
        var point = new Point(3, 4);

        Assert.Equal(3, point.X);
        Assert.Equal(4, point.Y);
    }

    [Fact]
    public void ToString_ReturnsCorrectStringRepresentation()
    {
        var point = new Point(3, 4);
        var result = point.ToString();

        Assert.Equal("(3, 4)", result);
    }

    [Theory]
    [InlineData(Direction.Right, 4, 4)]
    [InlineData(Direction.Left, 2, 4)]
    [InlineData(Direction.Up, 3, 5)]
    [InlineData(Direction.Down, 3, 3)]
    public void Next_MovesPointCorrectly(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(3, 4);
        var newPoint = point.Next(direction);

        Assert.Equal(expectedX, newPoint.X);
        Assert.Equal(expectedY, newPoint.Y);
    }

    [Theory]
    [InlineData(Direction.Right, 4, 3)]
    [InlineData(Direction.Left, 2, 5)]
    [InlineData(Direction.Up, 4, 5)]
    [InlineData(Direction.Down, 2, 3)]
    public void NextDiagonal_MovesPointDiagonallyCorrectly(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(3, 4);
        var newPoint = point.NextDiagonal(direction);

        Assert.Equal(expectedX, newPoint.X);
        Assert.Equal(expectedY, newPoint.Y);
    }

    // Przypadek brzegowy: testujemy punkt w pobliżu (0,0)
    [Theory]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Up, 0, 1)]
    [InlineData(Direction.Down, 0, -1)]
    public void Next_BorderCaseNearOrigin(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(0, 0);
        var newPoint = point.Next(direction);

        Assert.Equal(expectedX, newPoint.X);
        Assert.Equal(expectedY, newPoint.Y);
    }

    // Sprawdzanie, co się stanie, gdy kierunek jest nieznany (powinien zwrócić ten sam punkt)
    [Fact]
    public void Next_UnrecognizedDirection_ReturnsSamePoint()
    {
        var point = new Point(3, 4);
        var newPoint = point.Next((Direction)999);

        Assert.Equal(3, newPoint.X);
        Assert.Equal(4, newPoint.Y);
    }
}
