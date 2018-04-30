using System;

namespace LaundryReservation
{
  public class MachineDevice : IMachineDevice
  {
    /**
     * a device is unlocked for use by the user (i.e. a machine is always locked until the pin is entered). 
     * there is a difference between machine availability and lock.
     */
    public bool IsLocked { get; set; }
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