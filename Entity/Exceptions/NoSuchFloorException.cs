using System;
using System.Collections.Generic;
using System.Text;

namespace Even3.ElevatorSimulator.Exceptions
{
    public class NoSuchFloorException : Exception
    {
        public override string Message => "No such floor";
    }
}
