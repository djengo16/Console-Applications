using Area_51.Models;
using System;
using System.Linq;
using System.Threading;

namespace Area_51
{
    class Program
    {
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator(new Random());
            var agents =
                Enumerable.Range(1, 5)
                .Select(i => new Agent(elevator))
                .ToList();



            foreach (var agent in agents)
            {
                agent.MoveAround();
            }

            while (agents.Any(s => !s.HasLeft))
            {
                elevator.ElevatorWork();
            }

            Console.WriteLine("End of the program.");
        }
    }
}
