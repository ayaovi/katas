using System;
using LaundryReservation;
using NUnit.Framework;

namespace TestLaundryReservation
{
  [TestFixture]
  public class MachineDeviceTests
  {
    [Test]
    public void Unlock_GivenLockedState_ExpectIsLockedBeFalse()
    {
      //Arrange
      var device = new MachineDevice(Guid.NewGuid());
      //Act
      device.Unlock();

      //Assert
      Assert.IsFalse(device.IsLocked);
    }

    [Test]
    public void Lock_GivenUnlockedState_ExpectFalse()
    {
      //Arrange
      var device = new MachineDevice(Guid.NewGuid());

      //Act && Assert
      Assert.IsTrue(device.Lock(DateTime.Now));
    }

    [Test]
    public void Lock_GivenLockedState_ExpectFalse()
    {
      //Arrange
      var device = new MachineDevice(Guid.NewGuid());

      device.Lock(DateTime.Now);

      //Act && Assert
      Assert.IsFalse(device.Lock(DateTime.Now));
    }
  }
}
