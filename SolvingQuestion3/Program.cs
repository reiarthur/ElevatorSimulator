using Even3.ElevatorSimulator;
using System;

namespace SolvingQuestion3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1
            Person p1 = new Person(8, 0, "Leandro", false);
            Person p2 = new Person(0, 10, "Cláusio", false);
            Console.WriteLine("================= Question 1 =================");
            SolvingQuestion3.Run(10, 5, p1, p2);


            //Question2
            Person p3 = new Person(8, 0, "Leandro", false);
            Person p4 = new Person(0, 7, "Cláusio", false);
            Person p5 = new Person(3, 15, "Alana", false);
            Console.WriteLine("================= Question 2 =================");
            SolvingQuestion3.Run(20, 3, p3, p4, p5);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
