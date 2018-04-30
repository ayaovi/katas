using System;

namespace LaundryReservation
{
  public class TimeRange
  {
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public bool OverlapsWith(TimeRange range)
    {
      return !(range.Start > End || range.End < Start);
    }
  }
}