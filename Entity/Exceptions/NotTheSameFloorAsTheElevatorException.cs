using System;
using System.Collections.Generic;
using System.Text;

namespace Even3.ElevatorSimulator.Exceptions
{
    public class NotTheSameFloorAsTheElevatorException : Exception
    {
        public override string Message => "Person not in the same floor as the elevator.";
    }
}
