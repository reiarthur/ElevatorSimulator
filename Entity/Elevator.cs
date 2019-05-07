using Even3.ElevatorSimulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Even3.ElevatorSimulator
{
    public class Elevator
    {
        /// <summary>
        /// Gets or sets the max floor.
        /// </summary>
        /// <value>
        /// The max floor.
        /// </value>
        public int MaxFloor { get; set; }

        /// <summary>
        /// Gets or sets the floor in which the <see cref="Elevator"/> begins.
        /// </summary>
        /// <value>
        /// The floor in which the elevator begins.
        /// </value>
        public int InitialFloor { get; set; }

        /// <summary>
        /// Gets or sets the current floor.
        /// </summary>
        /// <value>
        /// The current floor.
        /// </value>
        public int CurrentFloor { get; set; }

        /// <summary>
        /// Gets or sets the people who are in the <see cref="Elevator"/>.
        /// </summary>
        /// <value>
        /// A list of people who are in the elevator.
        /// </value>
        public List<Person> PeopleInElevator { get; set; }

        /// <summary>
        /// Gets or sets the people who are waiting for the <see cref="Elevator"/>.
        /// </summary>
        /// <value>
        /// A list of people who are waiting for the elevator.
        /// </value>
        public List<Person> PeopleWaiting { get; set; }

        /// <summary>
        /// Gets or sets whether this <see cref="Elevator"/> is going up or down;
        /// </summary>
        /// <value>
        ///  <c>true</c> if it is going up; otherwise, <c>false</c>
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
        /// Gets or sets the floors in which the <see cref="Elevator"/> has to stop;
        /// </summary>
        /// <value>
        ///  A list of floor numbers in which are waiting for the <see cref="Elevator"/>.
        /// </value>
        public List<int> FloorsToVisit { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        /// /// <exception cref="NoSuchFloorException">
        /// Thrown if this <see cref="Person"/>'s initial or destination floor does not exist.
        /// </exception>
        public Elevator(int maxFloor, int initialFloor, bool goingUp, bool comments, params Person[] peopleWaiting)
        { 
            if ((maxFloor < 0 || initialFloor < 0 || initialFloor > maxFloor) ||
                peopleWaiting.Any(p => p.InitialFloor < 0 || p.InitialFloor > maxFloor ||
                  p.DestinationFloor < 0 || p.DestinationFloor > maxFloor))
            {
                throw new NoSuchFloorException();
            }

            MaxFloor = maxFloor;
            InitialFloor = initialFloor;
            CurrentFloor = initialFloor;
            PeopleInElevator = new List<Person>();
            PeopleWaiting = peopleWaiting.ToList();
            FloorsToVisit = new List<int>();
            GoingUp = goingUp;
            Comments = comments;
        }

        /// <summary>
        /// Makes the <see cref="Elevator"/> go up by 1 floor.
        /// </summary>
        public void Up()
        {
            if (Comments)
                Console.WriteLine("Going up...");
            CurrentFloor += 1;
        }

        /// <summary>
        /// Makes the <see cref="Elevator"/> go down by 1 floor.
        /// </summary>
        public void Down()
        {
            if (Comments)
                Console.WriteLine("Going down... ");
            CurrentFloor -= 1;
        }

        /// <summary>
        /// Choose the direction in which the <see cref="Elevator"/> should move.
        /// </summary>
        public void ChooseDirection()
        {
            if (GoingUp)
            {
                if (FloorsToVisit.All(f => f < CurrentFloor))
                {
                    GoingUp = false;
                }
            }
            else
            {
                if (FloorsToVisit.All(f => f > CurrentFloor))
                {
                    GoingUp = true;
                }
            }
        }

        /// <summary>
        /// Calculate all floors the <see cref="Elevator"/> has to visit.
        /// </summary>
        public void CalculateFloorsToVisit()
        {
            FloorsToVisit = PeopleWaiting.Select(p => p.InitialFloor).ToList();
            FloorsToVisit.AddRange(PeopleInElevator.Select(p => p.DestinationFloor));
        }


        /// <summary>
        /// Check if someone is going to get in the <see cref="Elevator"/>
        /// </summary>
        public void CheckIfItHasToGetPeople()
        {
            foreach (Person person in PeopleWaiting.ToList())
            {
                if (person.InitialFloor == CurrentFloor)
                {
                    if (person.GoingUp == GoingUp ||
                        (GoingUp && !person.GoingUp && !FloorsToVisit.Any(f => f > CurrentFloor)) ||
                        (!GoingUp && person.GoingUp && !FloorsToVisit.Any(f => f < CurrentFloor)))
                    {
                        person.GetInElevator(this);
                    }
                }
            }
        }

        /// <summary>
        /// Check if someone is going to leave the <see cref="Elevator"/>
        /// </summary>
        public void CheckIfItHasToLeavePeople()
        {
            foreach (Person person in PeopleInElevator.ToList())
            {
                if (person.DestinationFloor == CurrentFloor)
                {
                    person.LeaveElevator(this);
                }
            }
        }


        public void Run()
        {
            while (PeopleWaiting.Any() || PeopleInElevator.Any())
            {
                Console.Write($"Floor {CurrentFloor}. ");
                
                CheckIfItHasToGetPeople();
                CheckIfItHasToLeavePeople();

                CalculateFloorsToVisit();
                ChooseDirection();

                if (FloorsToVisit.Any())
                {
                    if (GoingUp)
                        Up();
                    else
                        Down();
                }

            }
        }
    }
}
