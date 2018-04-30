using System;
using LaundryReservation;
using NUnit.Framework;

namespace TestLaundryReservation
{
  [TestFixture]
  class TimeRangeTests
  {
    [Test]
    public void OverlapsWith_GivenNoOverlapping_ExpectFalse()
    {
      //Arrange
      var range1 = new TimeRange { Start = DateTime.Now, End = DateTime.Now.AddMinutes(30) };
      var range2 = new TimeRange { Start = DateTime.Now.AddMinutes(-31), End = DateTime.Now.AddMinutes(-1) };
      
      //Act && Assert
      Assert.IsFalse(range1.OverlapsWith(range2));
    }

    [Test]
    public void OverlapsWith_GivenOverlapping_ExpectTrue()
    {
      //Arrange
      var range1 = new TimeRange { Start = DateTime.Now, End = DateTime.Now.AddMinutes(30) };
      var range2 = new TimeRange { Start = DateTime.Now.AddMinutes(-31), End = DateTime.Now };

      //Act && Assert
      Assert.IsTrue(range1.OverlapsWith(range2));
    }
  }
}
