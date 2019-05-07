# ElevatorSimulator
Elevator Simulator made for Even3 tech challenge.

This .NET Core based solution contains a Class Library, a MSTest Test Project and three Console Applications. 
Each one of the Console Applications is an answer to the questions of the tech challenge by Even3.

With this solution, i tried to replicate an actual elevator, and how it would behave irl. however, elevators actually do not behave that way, because it could cause starvation.

A rooftop resident could wait to eternity for the elevator to come to their floor, if there were people on the lower floors always calling the elevator.
The developed classes ensure that whilst the elevator is going up, it will still be going up until the highest needed floor, after that, it can go down.

The rule is the same for the oppose, supposing the elevador is going down, the code ensure that it will go down by all the floors in which are waiting, after that it can go up.

For instance: Renato called the elevator. Renato is in 6th floor and want to go to the 9th. The elevator is coming to the 6th floor, however, it is going down, as Camila is in the elevator and requested to go to the 2nd floor. The elevator will not stop at the 6th floor. After it stops at 2nd floor, it will go up and stop at 6th floor, as Renato called.

Therefore, the efficiency requested by Even3 at the tech challenge will always respect the people in the building, so they do not starve, as a actual elevator works.

For this reason, the only remaining options to calculate the shortest path of the elevator will be: if it was previously going up or down.

*Even thought I did not use TDD thoroughly, the Test Project guided me to finish all the logic.*


**The logic used to answer the three questions can be found in the next three files:**

1. SolvingQuestion1/SolvingQuestion1.cs 
2. SolvingQuestion2/SolvingQuestion2.cs
3. SolvingQuestion3/SolvingQuestion3.cs
