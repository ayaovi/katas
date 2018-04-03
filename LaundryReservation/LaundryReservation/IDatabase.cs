using System;
using System.Collections.Generic;

namespace LaundryReservation
{
  public interface IDatabase
  {
    MachineDevice GetMachineDevice(Guid id);
    void AddMachineDevices(IEnumerable<MachineDevice> device);
    IEnumerable<Guid> GetAllMachineDeviceIds();
  }
}
