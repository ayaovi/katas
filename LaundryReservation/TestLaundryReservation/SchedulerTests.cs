using System;
using System.Collections.Generic;
using LaundryReservation;
using NSubstitute;
using NUnit.Framework;

namespace TestLaundryReservation
{
  [TestFixture]
  class SchedulerTests
  {
    [Test]
    public void Reserve_GivenNoPriorReservation_ExpectTrue()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var database = Substitute.For<IDatabase>();
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);
      
      //Act && Assert
      Assert.IsTrue(scheduler.Reserve(guid, DateTime.Now));
    }

    [Test]
    public void Reserve_GivenPriorReservation_ExpectFalse()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var database = Substitute.For<IDatabase>();
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);

      //Act
      scheduler.Reserve(guid, DateTime.Now);

      //Act && Assert
      Assert.IsFalse(scheduler.Reserve(guid, DateTime.Now));
    }
  }
}
