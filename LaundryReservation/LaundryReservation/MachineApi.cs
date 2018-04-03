using System;

namespace LaundryReservation
{
  public class MachineApi
  {
    private readonly IDatabase _database;
    private readonly IScheduler _scheduler;

    public MachineApi(IDatabase database, IScheduler scheduler)
    {
      _database = database;
      _scheduler = scheduler;
    }

    public bool LockMachine(Guid id, DateTime time)
    {
      var device = _database.GetMachineDevice(id);
      if (device != null)
      {
        return !device.IsLocked && _scheduler.Reserve(id, time);
      }
      return false;
    }
  }
}
