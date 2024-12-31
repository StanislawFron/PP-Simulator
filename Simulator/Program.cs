namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
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
}