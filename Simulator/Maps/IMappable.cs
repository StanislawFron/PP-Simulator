﻿namespace Simulator.Maps;

public interface IMappable
{
    /// <summary>
    /// Dodaje obiekt do mapy.
    /// </summary>
    void AddToMap(Map map, Point startPosition);

    /// <summary>
    /// Porusza obiektem w danym kierunku.
    /// </summary>
    string Go(Direction direction);

    /// <summary>
    /// Zwraca pozycję obiektu.
    /// </summary>
    Point? Position { get; }

    /// <summary>
    /// Zwraca nazwę obiektu.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Zwraca symbol obiektu.
    /// </summary>
    char Symbol { get; }

    /// <summary>
    /// Moc obiektu (opcjonalne pole).
    /// </summary>
    int Power { get; }
}
