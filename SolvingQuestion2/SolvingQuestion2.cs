using Even3.ElevatorSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvingQuestion2
{
    class SolvingQuestion2
    {
        public static void Run()
        {
            Person p1 = new Person(8, 0, "Welington", true);
            Person p2 = new Person(0, 7, "Camila", true);
            Person p3 = new Person(3, 15, "Alana", true);

            Elevator elevator = new Elevator(20, 3, false, true, p1, p2, p3);

            int steps = 0;

            elevator.CalculateFloorsToVisit();

            while (elevator.PeopleWaiting.Any() || elevator.PeopleInElevator.Any())
            {
                Console.Write("Floor " + elevator.CurrentFloor + ". ");

                elevator.CheckIfItHasToGetPeople();
                elevator.CheckIfItHasToLeavePeople();

                elevator.CalculateFloorsToVisit();
                elevator.ChooseDirection();

                if (elevator.FloorsToVisit.Any())
                {
                    steps++;

                    if (elevator.GoingUp)
                        elevator.Up();
                    else
                        elevator.Down();
                }

            }

            Console.WriteLine($"\nStopped. It took {steps} steps to complete.");
        }
    }
}
