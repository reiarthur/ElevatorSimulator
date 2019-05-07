using Even3.ElevatorSimulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Even3.ElevatorSimulator
{
    public class Person
    {
        /// <summary>
        /// Gets or sets the initial floor.
        /// </summary>
        /// <value>
        /// The initial floor.
        /// </value>
        public int InitialFloor { get; set; }

        /// <summary>
        /// Gets or sets the destination floor.
        /// </summary>
        /// <value>
        /// The destination floor.
        /// </value>
        public int DestinationFloor { get; set; }

        /// <summary>
        /// Gets or sets the person's name.
        /// </summary>
        /// <value>
        /// The person's name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheter this <see cref="Person"/> is going up.
        /// </summary>
        /// <value>
        ///     <c>true</c> if is going up; otherwise, <c>false</c>.
        /// </value>
        public bool GoingUp { get; set; }

        /// <summary>
        /// Gets or sets whether the comments will by displayed;
        /// </summary>
        /// <value>
        ///  <c>true</c> if it is going to be displayed; otherwise, <c>false</c>
        /// </value>
        public bool Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person(int initialFloor, int destinationFloor, string name, bool comments = true)
        {
            InitialFloor = initialFloor;
            DestinationFloor = destinationFloor;
            Name = name;
            GoingUp = initialFloor < destinationFloor;
            Comments = comments;
        }

        /// <summary>
        /// This <see cref="Person"/> gets in an <see cref="Elevator"/>
        /// </summary>
        /// <param name="elevator">The elevator</param>
        /// <exception cref="NotTheSameFloorAsTheElevatorException">
        /// Thrown if this <see cref="Person"/> is not at the same floor as the <see cref="Elevator"/>.
        /// </exception>

        public void GetInElevator(Elevator elevator)
        {
            if (InitialFloor != elevator.CurrentFloor)
            {
                throw new NotTheSameFloorAsTheElevatorException();
            }
            if (Comments)
                Console.Write($"{Name} got in the elevator. ");
            elevator.PeopleInElevator.Add(this);
            elevator.PeopleWaiting.Remove(this);
        }

        /// <summary>
        /// This <see cref="Person"/> leaves an <see cref="Elevator"/>
        /// </summary>
        /// <param name="elevator">The elevator</param>
        /// <exception cref="PersonNotInElevatorException">
        /// Thrown if this <see cref="Person"/> is not in the <see cref="Elevator"/>.
        /// </exception>
        public void LeaveElevator(Elevator elevator)
        {
            if (!elevator.PeopleInElevator.Contains(this))
            {
                throw new PersonNotInElevatorException();
            }
            if (Comments)
                Console.Write($"{Name} left the elevator. ");
            elevator.PeopleInElevator.Remove(this);
        }
    }
}
