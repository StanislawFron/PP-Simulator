namespace Simulator.Maps;
public class SmallTorusMap : Map
{
    public int Size { get; }
    private readonly Rectangle _map;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Blad! - Poprawny rozmiar mapy to od od 5 do 20 punktow.");
        }
        Size = size;
        _map = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point point)
    {
        return _map.Contains(point);
    }

    public override Point Next(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(point.X, (point.Y + 1) % Size),
            Direction.Down => new Point(point.X, (point.Y - 1 + Size) % Size),
            Direction.Left => new Point((point.X - 1 + Size) % Size, point.Y),
            Direction.Right => new Point((point.X + 1) % Size, point.Y),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point((point.X + 1) % Size, (point.Y + 1) % Size),
            Direction.Down => new Point((point.X - 1 + Size) % Size, (point.Y - 1 + Size) % Size),
            Direction.Left => new Point((point.X - 1 + Size) % Size, (point.Y + 1) % Size),
            Direction.Right => new Point((point.X + 1) % Size, (point.Y - 1 + Size) % Size),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }
}
