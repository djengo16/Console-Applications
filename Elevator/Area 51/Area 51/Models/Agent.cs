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
            this.SecurityLevel = (SecurityLevel)random.Next(1, 4);
            this.Name = "[" + random.Next(100).ToString() + "]" + "-" + this.SecurityLevel.ToString();
        }
        public string Name { get; private set; }

        public SecurityLevel SecurityLevel { get; set; }

        public bool HasLeft { get; set; }

        public int CurrentFloor { get; set; }

        private void MoveAroundInternal()
        {
            ;
            while (true)
            {
                AriveAtTheBase();

                int randomAction = 1;//random.Next(2);
                if(randomAction == 1)
                {
                    //Thread thread = new Thread(() => elevator.Call(this));
                    //thread.Start();
                    this.elevator.Call(this);

                    Thread elevatorThread = new Thread(this.elevator.ElevatorWork);
                    elevatorThread.Start();
                    elevatorThread.Join();

                    return;
                    
                }
                if(randomAction == 0 && CurrentFloor == 0)
                {
                    HasLeft = true;
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
