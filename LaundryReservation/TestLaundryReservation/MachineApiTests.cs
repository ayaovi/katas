using System;
using System.Collections.Generic;
using LaundryReservation;
using NSubstitute;
using NUnit.Framework;

namespace TestLaundryReservation
{
  [TestFixture]
  class MachineApiTests
  {
    [Test]
    public void LockDevice_GivenUnlockState_ExpectTrue()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var database = Substitute.For<IDatabase>();
      database.GetMachineDevice(guid).Returns(new MachineDevice(guid));
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);
      var api = new MachineApi(database, scheduler);

      //Act && Assert
      Assert.IsTrue(api.LockMachine(guid, DateTime.Now));
    }

    [Test]
    public void LockDevice_GivenLockedState_ExpectFalse()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var database = Substitute.For<IDatabase>();
      database.GetMachineDevice(guid).Returns(new MachineDevice(guid) { IsLocked = true });
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);
      var api = new MachineApi(database, scheduler);

      //Act && Assert
      Assert.IsFalse(api.LockMachine(guid, DateTime.Now));
    }

    [Test]
    public void LockDevice_GivenAlreadyReservedSlot_ExpectFalse()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var database = Substitute.For<IDatabase>();
      database.GetMachineDevice(guid).Returns(new MachineDevice(guid) { IsLocked = true });
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);
      var api = new MachineApi(database, scheduler);

      //Act
      scheduler.Reserve(guid, DateTime.Now);

      //Act && Assert
      Assert.IsFalse(api.LockMachine(guid, DateTime.Now));
    }

    [Test]
    public void UnlockDevice_GivenLockedState_ExpectDeciveUnlocked()
    {
      //Arrange
      var guid = Guid.NewGuid();
      var device = new MachineDevice(guid);
      var database = Substitute.For<IDatabase>();
      database.GetMachineDevice(guid).Returns(device);
      database.GetAllMachineDeviceIds().Returns(new List<Guid> { guid });
      var scheduler = new Scheduler(database);
      var api = new MachineApi(database, scheduler);

      //Act
      api.UnlockMachine(guid);

      //Act && Assert
      Assert.IsFalse(device.IsLocked);
    }
  }
}
