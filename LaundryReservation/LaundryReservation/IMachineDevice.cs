using System;

namespace LaundryReservation
{
  public interface IMachineDevice
  {
    bool Lock(DateTime reservationDateTime);
    void Unlock();
  }
}
