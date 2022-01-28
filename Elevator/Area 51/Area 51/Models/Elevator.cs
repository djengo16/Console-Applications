namespace Area_51.Models
{
    using Area_51.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Elevator
    {
        private readonly Random random;

        public Elevator(Random random)
        {
            this.random = random;
            this.ElevatorCalls = new Queue<ElevatorCall>();
        }

        public int CurrentFloor { get; set; }

        public Agent AgentInElevator { get; set; }

        public Queue<ElevatorCall> ElevatorCalls { get; set; }

        public void EnterElevator(Agent agent)
        {
                AgentInElevator = agent;
        }

        public void Exit(Agent agent)
        {
            Console.WriteLine(String.Format("- {0} exit the elevator.", agent.Name + agent.SecurityLevel));

                AgentInElevator = null;
        }

        public void MoveAfterButtonClicked()
        {
            
            int targetFloor = random.Next(4);

            this.MoveToTargetFloor(targetFloor);

            if (this.AgentInElevator.SecurityLevel == SecurityLevel.Confidential
                && (FloorType)CurrentFloor == FloorType.G)
            {
                AgentInElevator.CurrentFloor = targetFloor;
                this.Exit(this.AgentInElevator);
                return;
            }
            else if (this.AgentInElevator.SecurityLevel == SecurityLevel.Secret
                && ((FloorType)CurrentFloor == FloorType.G
                || (FloorType)CurrentFloor == FloorType.S))
            {
                AgentInElevator.CurrentFloor = targetFloor;
                this.Exit(this.AgentInElevator);
                return;
            }
            else if(this.AgentInElevator.SecurityLevel == SecurityLevel.TopSecret)
            {
                AgentInElevator.CurrentFloor = targetFloor;
                this.Exit(this.AgentInElevator);
                return;
            }
            else
            {
                Console.WriteLine("Agent can't acces this floor.Choosing another floor...");
                // if it's not one of this cases , the agent clicks the elevator button again 
                 MoveAfterButtonClicked();
            }
        }

        public void ElevatorWork()
        {
            ;
            if (!ElevatorCalls.Any())
            {
                return;
            }

             var currentCall = this.ElevatorCalls.Dequeue();
            var currentAgent = currentCall.Agent;

            MoveToTargetFloor(currentAgent.CurrentFloor);
            // agent calls the elevator and enters it

            Console.WriteLine(String.Format("{0} entered the elevator.", currentAgent.Name));

            this.AgentInElevator = currentAgent;

            MoveAfterButtonClicked();
        }

        public void  Call(Agent agent)
        {
            Console.WriteLine(String.Format("{0} called the elevator.",agent.Name));
            this.ElevatorCalls.Enqueue(new ElevatorCall { Agent = agent });            
        }

        public void MoveToTargetFloor(int targetFloor)
        {            
            if (targetFloor > CurrentFloor)
            {
                for (int i = CurrentFloor; i <= targetFloor; i++)
                {
                    
                    Thread.Sleep(1000); // second per floor
                    Console.WriteLine(String.Format("The elevator is at {0} floor", (FloorType)i));                    
                }
                CurrentFloor = targetFloor;
            }
            else if(targetFloor < CurrentFloor)
            {
                for (int i = CurrentFloor; i >= targetFloor; i--)
                {
                    Thread.Sleep(1000); // second per floor
                    Console.WriteLine(String.Format("The elevator is at {0} floor", (FloorType)i));
                }
                CurrentFloor = targetFloor;
            }
        }
    }
}
