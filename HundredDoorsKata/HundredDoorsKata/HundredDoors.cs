using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredDoorsKata
{
  public class HundredDoors
  {
    public static IEnumerable<Door> Pass(IEnumerable<Door> doors, int i, int max)
    {
      if (i > max) return doors;
      var i1 = i;
      return Pass(doors.Select(door => door.Index % i1 == 0 ? Toggle(door) : new Door { Status = door.Status, Index = door.Index }), ++i, max);
    }

    private static Door Toggle(Door arg)
    {
      switch (arg.Status)
      {
        case State.Open:
          return new Door { Status = State.Holding, Index = arg.Index };
        case State.Holding:
          return new Door { Status = State.Closed, Index = arg.Index };
      }
      return new Door { Status = State.Open, Index = arg.Index };
    }
  }

  public class Door
  {
    public State Status { get; set; } = State.Open;
    public int Index { get; set; }
  }

  public enum State
  {
    Open, Holding, Closed
  }
}
