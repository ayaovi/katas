using System;
using System.Collections.Generic;
using System.Linq;

namespace LaundryReservation
{
  public class Database : IDatabase
  {
    private readonly IEnumerable<MachineDevice> _devices;

    public Database()
    {
      _devices = new List<MachineDevice>();
    }

    public MachineDevice GetMachineDevice(Guid id)
    {
      return _devices.SingleOrDefault(x => x.Id == id);
    }

    public void AddMachineDevices(IEnumerable<MachineDevice> device)
    {
      _devices.Concat(device);
    }

    public IEnumerable<Guid> GetAllMachineDeviceIds()
    {
      return _devices.Select(x => x.Id);
    }
  }
}