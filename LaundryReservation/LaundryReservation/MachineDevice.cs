using System;

namespace LaundryReservation
{
  public class MachineDevice : IMachineDevice
  {
    public bool IsLocked { get; private set; }
    public Guid Id { get; }

    public MachineDevice(Guid id)
    {
      Id = id;
    }

    public bool Lock(DateTime reservationDateTime)
    {
      if (IsLocked) return false;
      IsLocked = true;
      return true;
    }

    public void Unlock()
    {
      IsLocked = false;
    }
  }
}