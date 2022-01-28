namespace Area_51.Models
{
    using Area_51.Models.Enums;
    using System;
    using System.Threading;

    public class Agent
    {
        private readonly Elevator elevator;

        Random random = new Random();
        public Agent(Elevator elevator)
        {
            this.elevator = elevator;
            this.SecurityLevel = (SecurityLevel)random.Next(1, 2);
            this.Name = "[" + random.Next(100).ToString() + "]" + "-" + this.SecurityLevel.ToString();
        }
        public string Name { get; private set; }

        public SecurityLevel SecurityLevel { get; set; }

        public bool HasLeft { get; set; }

        public int CurrentFloor { get; set; }

        private void MoveAroundInternal()
        {
            
            AriveAtTheBase();
            
            while (true)
            {
                int rnd = random.Next(10);

                int randomAction = rnd > 7 ? 0 : 1;

                if (randomAction == 1)
                {
                    this.elevator.Call(this);

                    Thread elevatorThread = new Thread(this.elevator.ElevatorWork);
                    elevatorThread.Start();
                    elevatorThread.Join();
                }
                if (randomAction == 0 && CurrentFloor == 0)
                {
                    HasLeft = true;
                    Console.WriteLine(String.Format("{0} left the base.",this.Name));
                    return;
                }
            }
        }

        private void AriveAtTheBase()
        {
            this.CurrentFloor = 0;
            Console.WriteLine(String.Format("{0} arrived to ground floor.", this.Name));
        }

        public void MoveAround()
        {
            Thread t = new Thread(MoveAroundInternal);
            t.Start();
            t.Join();
        }
    }
}
