using System;

namespace LaundryReservation
{
  public class LaundryMaster
  {
    private INotificationHandler _notificationHandler;
    private IDatabase _database;
    private IScheduler _scheduler;
    private readonly MachineApi _api;

    public LaundryMaster(INotificationHandler notificationHandler, IDatabase database, IScheduler scheduler)
    {
      _notificationHandler = notificationHandler;
      _database = database;
      _scheduler = scheduler;
      _api = new MachineApi(database, scheduler);
    }

    public void CreateReservation(DateTime time, string cell, string email)
    {
      
    }

    public void ClaimReservation(string pin, Guid machineId)
    {
      // upon successfull auth.
      _api.UnlockMachine(machineId);
    }
  }
}