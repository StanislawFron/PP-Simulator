namespace Simulator.Maps;

internal class SmallSquareMap : Map
{
    public int Size { get; }
    private readonly Rectangle _map;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Rozmiar mapy musi mieścić się w granicach od 5 do 20 punktow!");
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
        Point next = point.Next(direction);
        return Exist(next) ? next : point;
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        Point next = point.NextDiagonal(direction);
        return Exist(next) ? next : point;
    }
}