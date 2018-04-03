using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HundredDoorsKata;
using NUnit.Framework;

namespace HundredDoorsTests
{
  [TestFixture]
  public class HundredDoorsTest
  {
    //[TestCase(2, "@H", TestName = "Two Doors")]
    //[TestCase(3, "@HH", TestName = "Three Doors")]
    [TestCase(4, "@HH#", TestName = "Foor Doors")]
    //[TestCase(100, "@##@####@######@########@##########@############@##############@################@##################@", TestName = "Hundred Doors")]
    //[TestCase(2, "@@")]
    public void Pass_GivenDoors_ExpectResult(int numberOfDoors, string expected)
    {
      //Arrange
      var doors = Enumerable.Range(1, numberOfDoors).Select(i => new Door{Status = State.Closed, Index = i}).ToArray();

      //Act
      var result = HundredDoors.Pass(doors, 1, numberOfDoors);

      //Assert
      GetStringValue(result).ShouldBeEquivalentTo(expected);
    }

    private string GetStringValue(IEnumerable<Door> doors) => string.Concat(doors.Select(door =>
    {
      switch (door.Status)
      {
        case State.Open:
          return "@";
        case State.Holding:
          return "H";
      }
      return "#";
    }));
  }
}
