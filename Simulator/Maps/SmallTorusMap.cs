namespace Simulator.Maps;
public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) {}

    public override Point Next(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(point.X, (point.Y + 1) % SizeY),
            Direction.Down => new Point(point.X, (point.Y - 1 + SizeY) % SizeY),
            Direction.Left => new Point((point.X - 1 + SizeX) % SizeX, point.Y),
            Direction.Right => new Point((point.X + 1) % SizeX, point.Y),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point((point.X + 1) % SizeX, (point.Y + 1) % SizeY),
            Direction.Down => new Point((point.X - 1 + SizeX) % SizeX, (point.Y - 1 + SizeY) % SizeY),
            Direction.Left => new Point((point.X - 1 + SizeX) % SizeX, (point.Y + 1) % SizeY),
            Direction.Right => new Point((point.X + 1) % SizeX, (point.Y - 1 + SizeY) % SizeY),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }
}
