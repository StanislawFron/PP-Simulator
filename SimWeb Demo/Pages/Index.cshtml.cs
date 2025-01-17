using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;
public class IndexModel : PageModel
{
    public int Turn { get; private set; } = 0;
    public SimulationTurnLog CurrentLog { get; private set; }
    public int SizeX { get; } = 8;
    public int SizeY { get; } = 8;
    public Simulation Simulation { get; private set; }
    public SimulationHistory SimHistory { get; private set; }
    public void SimInit()
    {
        SmallTorusMap map = new(SizeX, SizeY);
        List<IMappable> creatures = [
            new Orc("Gorbag", 2, 5),
            new Elf("Elandor", 3, 3),
            new Animals{ Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false },
            new Tower { Description = "Watchtower", Level = 1 },
            new Tower { Description = "Defense Tower", Level = 2 }
            ];
        List<Point> points = [
            new(2, 2),
            new(3, 1),
            new(3, 3),
            new(6, 5),
            new(5, 5),
            new(4, 4),
            new(7, 7)
            ];
        string moves = "rrllrruulludllrl";
        Simulation = new(map, creatures, points, moves);
        SimHistory = new SimulationHistory(Simulation);
        CurrentLog = SimHistory.TurnLogs[Turn];
    }
    public void OnGet()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (Simulation == null)
        {
            SimInit();
        }
    }
    public void OnPostNextTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (SimHistory == null)
        {
            SimInit();
        }
        if (Turn < SimHistory.TurnLogs.Count - 1)
        {
            Turn++;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }
    public void OnPostPrevTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (SimHistory == null)
        {
            SimInit();
        }
        if (Turn > 0)
        {
            Turn--;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = SimHistory.TurnLogs[Turn];
        }
    }
}