namespace Area_51.Models
{
    public class ElevatorCall
    {
        public Agent Agent { get; set; }

        public int TargetFloor => this.Agent.CurrentFloor;
    }
}
