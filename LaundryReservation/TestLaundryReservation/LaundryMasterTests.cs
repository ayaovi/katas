using System;
using LaundryReservation;
using NSubstitute;
using NUnit.Framework;

namespace TestLaundryReservation
{
  [TestFixture]
  class LaundryMasterTests
  {
    [Test]
    public void CreateReservation_GivenParameters_ExpectSuccess()
    {
      //Arrange
      var notificationHandler = Substitute.For<INotificationHandler>();
      var database = Substitute.For<IDatabase>();
      var scheduler = Substitute.For<IScheduler>();
      var master = new LaundryMaster(notificationHandler, database, scheduler);

      //Act
      master.CreateReservation(DateTime.Now, "123456789", "test@test.com");

      //Assert
    }
  }
}
