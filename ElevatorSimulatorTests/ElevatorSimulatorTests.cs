using Even3.ElevatorSimulator;
using Even3.ElevatorSimulator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ElevatorSimulatorTests
{
    [TestClass]
    public class ElevatorSimulatorTests
    {
        [TestMethod]
        public void CallElevatorToGoUp()
        {
            Person p1 = new Person(5, 7, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
            Assert.AreEqual(1, e1.PeopleWaiting.Count());
            Assert.AreEqual(true, e1.GoingUp);
        }

        [TestMethod]
        public void CallElevatorToGoDown()
        {
            Person p1 = new Person(5, 3, "Person");
            Elevator e1 = new Elevator(10, 3, false, false, p1);
            Assert.AreEqual(1, e1.PeopleWaiting.Count());
            Assert.AreEqual(false, e1.GoingUp);
        }

        [TestMethod]
        public void PersonInElevator()
        {
            Person p1 = new Person(5, 8, "Person");
            Elevator e1 = new Elevator(10, 5, true, false, p1);
            p1.GetInElevator(e1);
            Assert.AreEqual(1, e1.PeopleInElevator.Count());
            Assert.AreEqual(true, e1.PeopleInElevator.Contains(p1));
        }

        [TestMethod]
        public void PersonLeftElevator()
        {
            Person p1 = new Person(5, 8, "Person", false);
            Elevator e1 = new Elevator(10, 5, true, false, p1);
            p1.GetInElevator(e1);
            p1.LeaveElevator(e1);
            Assert.AreEqual(0, e1.PeopleInElevator.Count());
            Assert.AreEqual(false, e1.PeopleInElevator.Contains(p1));
        }

        [TestMethod]
        public void ElevatorArrivedWhenCalled()
        {
            Person p1 = new Person(5, 8, "Person");
            Person p2 = new Person(9, 4, "Person2");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
            e1.Run();
            Assert.AreEqual(8, e1.CurrentFloor);

            e1.PeopleWaiting.Add(p2);
            e1.Run();
            Assert.AreEqual(4, e1.CurrentFloor);
        }

        [TestMethod]
        public void ElevatorArrivedWhenCalled2()
        {
            Person p1 = new Person(5, 8, "Person");
            Person p2 = new Person(9, 4, "Person2");
            Elevator e1 = new Elevator(10, 0, true, false, p1, p2);
            e1.Run();
            Assert.AreEqual(4, e1.CurrentFloor);
        }

        [TestMethod]
        public void ElevatorArrivedWhenCalled3()
        {
            Person p1 = new Person(5, 8, "Person");
            Person p2 = new Person(9, 4, "Person2");
            Elevator e1 = new Elevator(10, 10, true, false, p1, p2);
            e1.Run();
            Assert.AreEqual(8, e1.CurrentFloor);
        }

        [TestMethod]
        public void MultiplePeopleWithSameJourney()
        {
            Person p1 = new Person(5, 8, "Person");
            Person p2 = new Person(5, 8, "Person2");
            Person p3 = new Person(5, 8, "Person3");

            Elevator e1 = new Elevator(10, 0, true, false, p1, p2, p3);
            Assert.AreEqual(3, e1.PeopleWaiting.Count());
            e1.Run();
            Assert.AreEqual(8, e1.CurrentFloor);
        }

        [TestMethod]
        public void PersonArrivedAtDesiredFloorAndLeft()
        {
            Person p1 = new Person(5, 8, "Person");
            Elevator e1 = new Elevator(10, 3, true, false, p1);
            e1.Run();
            Assert.AreEqual(0, e1.PeopleInElevator.Count());
            Assert.AreEqual(0, e1.PeopleWaiting.Count());
            Assert.AreEqual(8, e1.CurrentFloor);
        }

        [TestMethod]
        public void PersonIsGoingUp()
        {
            Person p1 = new Person(3, 7, "Person");
            Assert.AreEqual(true, p1.GoingUp);
        }

        [TestMethod]
        public void PersonIsGoingDown()
        {
            Person p1 = new Person(8, 4, "Person");
            Assert.AreEqual(false, p1.GoingUp);
        }

        [TestMethod]
        [ExpectedException(typeof(NotTheSameFloorAsTheElevatorException))]
        public void CantGetInTheElevator()
        {
            Person p1 = new Person(5, 8, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
            p1.GetInElevator(e1);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonNotInElevatorException))]
        public void CantLeaveTheElevator()
        {
            Person p1 = new Person(3, 7, "Person");
            Elevator e1 = new Elevator(10, 3, true, false, p1);

            p1.LeaveElevator(e1);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void PersonIsHigherThanExpected()
        {
            Person p1 = new Person(15, 9, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void PersonDestinationIsHigherThanExpected()
        {
            Person p1 = new Person(8, 11, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void PersonIsLowerThanExpected()
        {
            Person p1 = new Person(-1, 6, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void PersonDestinationIsLowerThanExpected()
        {
            Person p1 = new Person(5, -1, "Person");
            Elevator e1 = new Elevator(10, 0, true, false, p1);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void ElevatorMaxFloorIsLowerThanExpected()
        {
            Elevator e1 = new Elevator(-1, 0, true, false);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void ElevatorInitialFloorIsLowerThanExpected()
        {
            Elevator e1 = new Elevator(0, -1, true, false);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchFloorException))]
        public void ElevatorInitialFloorIsHigherThanExpected()
        {
            Elevator e1 = new Elevator(10, 11, true, false);
        }
    }
}
