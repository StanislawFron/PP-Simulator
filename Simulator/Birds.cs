namespace Simulator;

public class Birds : Animals
{
    public bool CanFly = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Go(Direction direction)
    {
        if (currentMap != null && Position != null)
        {
            if (CanFly)
            {
                var newPos = currentMap.Next(Position.Value, direction);
                newPos = currentMap.Next(newPos, direction);
                currentMap.Move(this, Position.Value, newPos);
                SetPosition(newPos);
            }
            else
            {
                var newPos = currentMap.NextDiagonal(Position.Value, direction);
                currentMap.Move(this, Position.Value, newPos);
                SetPosition(newPos);
            }
            return $"{direction.ToString().ToLower()}";
        }
        else
        {
            throw new InvalidOperationException("Blad! - Zwierze nie ma jeszcze przydzielonej mapy.");
        }
    }
}
