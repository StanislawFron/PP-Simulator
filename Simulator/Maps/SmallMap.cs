namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Rozmiar mapy musi mieścić się w granicach od 5 do 20 punktow!");
    }
}
