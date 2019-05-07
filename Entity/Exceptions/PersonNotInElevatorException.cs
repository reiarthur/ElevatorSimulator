using System;
using System.Collections.Generic;
using System.Text;

namespace Even3.ElevatorSimulator.Exceptions
{
    public class PersonNotInElevatorException : Exception
    {
        public override string Message => "Person not in the elevator.";
    }
}
