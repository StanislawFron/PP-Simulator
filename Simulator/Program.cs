using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        // Test 1: Poprawne utworzenie prostokąta
        Console.WriteLine("Test 1: Tworzenie prostokąta z (5, 10) do (15, 20)");
        Rectangle rect1 = new Rectangle(5, 10, 15, 20);
        Console.WriteLine(rect1); // Oczekiwany: (5, 10):(15, 20)

        // Test 2: Tworzenie prostokąta z "zamieszanych" współrzędnych
        Console.WriteLine("Test 2: Tworzenie prostokąta z (15, 20) do (5, 10)");
        Rectangle rect2 = new Rectangle(15, 20, 5, 10);
        Console.WriteLine(rect2); // Oczekiwany: (5, 10):(15, 20)

        // Test 3: Sprawdzanie zawierania punktu wewnątrz prostokąta
        Console.WriteLine("Test 3: Czy prostokąt (5, 10):(15, 20) zawiera punkt (10, 15)?");
        Point point1 = new Point(10, 15);
        Console.WriteLine(rect1.Contains(point1)); // Oczekiwany: True

        // Test 4: Sprawdzanie punktu spoza prostokąta
        Console.WriteLine("Test 4: Czy prostokąt (5, 10):(15, 20) zawiera punkt (20, 30)?");
        Point point2 = new Point(20, 30);
        Console.WriteLine(rect1.Contains(point2)); // Oczekiwany: False

        // Test 5: Próba utworzenia "chudego" prostokąta
        Console.WriteLine("Test 5: Tworzenie prostokąta ze współrzędnymi (10, 10) do (10, 20)");
        try
        {
            Rectangle invalidRect = new Rectangle(10, 10, 10, 20);
            Console.WriteLine(invalidRect); // Nie powinno być wywołane
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}"); // Oczekiwany: Błąd: Prostokąt nie może być 'chudy' (punkty współliniowe).
        }

        // Test 6: Tworzenie prostokąta z punktami
        Console.WriteLine("Test 6: Tworzenie prostokąta z punktów (1, 2) i (4, 5)");
        Point p1 = new Point(1, 2);
        Point p2 = new Point(4, 5);
        Rectangle rect3 = new Rectangle(p1, p2);
        Console.WriteLine(rect3); // Oczekiwany: (1, 2):(4, 5)
    }

    static void Lab5b()
    {
        Console.WriteLine("=== Testy klasy SmallSquareMap ===");

        // Test 1: Poprawne utworzenie mapy
        var map = new SmallSquareMap(10);
        Console.WriteLine($"Rozmiar mapy: {map.Size}"); // Oczekiwany wynik: 10

        // Test 2: Punkt startowy i ruch w górę
        var start = new Point(5, 5);
        Console.WriteLine($"Punkt startowy: {start}"); // Oczekiwany wynik: (5, 5)

        var nextUp = map.Next(start, Direction.Up);
        Console.WriteLine($"Ruch w górę: {nextUp}"); // Oczekiwany wynik: (5, 6)

        var nextRight = map.Next(start, Direction.Right);
        Console.WriteLine($"Ruch w prawo: {nextRight}"); // Oczekiwany wynik: (6, 5)

        // Test 3: Próba wyjścia poza mapę
        var outOfBounds = map.Next(new Point(0, 0), Direction.Left);
        Console.WriteLine($"Próba ruchu w lewo z (0, 0): {outOfBounds}"); // Oczekiwany wynik: (0, 0)

        var diagonalOutOfBounds = map.NextDiagonal(new Point(0, 0), Direction.Left);
        Console.WriteLine($"Próba ruchu diagonalnego w lewo z (0, 0): {diagonalOutOfBounds}"); // Oczekiwany wynik: (0, 0)

        // Test 4: Próba utworzenia mapy o zbyt małym rozmiarze
        try
        {
            var tooSmallMap = new SmallSquareMap(3);
            Console.WriteLine($"Nieoczekiwany wynik: mapa o rozmiarze {tooSmallMap.Size}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Poprawnie zgłoszony błąd dla zbyt małej mapy: {ex.Message}");
        }

        // Test 5: Próba utworzenia mapy o zbyt dużym rozmiarze
        try
        {
            var tooLargeMap = new SmallSquareMap(25);
            Console.WriteLine($"Nieoczekiwany wynik: mapa o rozmiarze {tooLargeMap.Size}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Poprawnie zgłoszony błąd dla zbyt dużej mapy: {ex.Message}");
        }

        // Test 6: Próba sprawdzenia nieistniejącego punktu
        var invalidPoint = new Point(-1, -1);
        Console.WriteLine($"Punkt {invalidPoint} istnieje na mapie: {map.Exist(invalidPoint)}"); // Oczekiwany wynik: false

        Console.WriteLine("=== Testy zakończone ===");
    }
}