using Even3.ElevatorSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvingQuestion1
{
    class SolvingQuestion1
    {

        public static void Run()
        {
            Person p1 = new Person(8, 0, "Leandro", true);
            Person p2 = new Person(0, 10, "Cláusio", true);

            Elevator elevator = new Elevator(10, 5, true, true, p1, p2);

            int steps = 0;
            
            while (elevator.PeopleWaiting.Any() || elevator.PeopleInElevator.Any())
            {
                Console.Write($"Floor {elevator.CurrentFloor}. ");

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
