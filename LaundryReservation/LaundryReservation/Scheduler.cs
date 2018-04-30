using System;
using System.Collections.Generic;
using System.Linq;

namespace LaundryReservation
{
  public interface IScheduler
  {
    bool Reserve(Guid machineId, DateTime time);
  }

  public class Scheduler : IScheduler
  {
    private readonly IDictionary<Guid, IList<TimeRange>> _schedules;

    public Scheduler(IDatabase database)
    {
      _schedules = new Dictionary<Guid, IList<TimeRange>>();
      database.GetAllMachineDeviceIds().ToList().ForEach(x => _schedules.Add(x, new List<TimeRange>()));
    }

    public bool Reserve(Guid machineId, DateTime time)
    {
      if (!_schedules.TryGetValue(machineId, out var schedule)) return false;
      if (schedule.Any(x => x.OverlapsWith(new TimeRange { Start = time, End = time.AddMinutes(30) }))) return false;
      schedule.Add(new TimeRange { Start = time, End = time.AddMinutes(30) });
      return true;
    }
  }
}
