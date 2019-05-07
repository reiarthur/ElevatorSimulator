using Even3.ElevatorSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvingQuestion3
{
    class SolvingQuestion3
    {
        public static void Run(int maxFloors, int initialFloor, params Person[] people)
        {
            if (people == null)
            {
                throw new ArgumentNullException(nameof(people));
            }

            int stepsIfStartGoingUp = CalculateSteps(maxFloors, initialFloor, true, people);
            int stepsIfStartGoingDown = CalculateSteps(maxFloors, initialFloor, false, people);

            Console.WriteLine($"Steps taken if elevator starts by going up: {stepsIfStartGoingUp}.");
            Console.WriteLine($"Steps taken if elevator starts by going down: {stepsIfStartGoingDown}.");

            if (stepsIfStartGoingUp < stepsIfStartGoingDown)
                Console.WriteLine($"Best case scenario: elevator starts by going up.\n\n");
            else if (stepsIfStartGoingDown < stepsIfStartGoingUp)
                Console.WriteLine($"Best case scenario: elevator starts by going down.\n\n");
            else
                Console.WriteLine($"Best case scenario: whatever, dude. They're the same.\n\n");


        }

        private static int CalculateSteps(int maxFloors, int initialFloor, bool goingUp, params Person[] people)
        {
            int steps = 0;

            Elevator elevator = new Elevator(maxFloors, initialFloor, goingUp, false, people);
            elevator.CalculateFloorsToVisit();

            while (elevator.PeopleWaiting.Any() || elevator.PeopleInElevator.Any())
            {
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
            return steps;
        }
    }
}
