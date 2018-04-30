using System;

namespace LaundryReservation
{
  public interface INotificationHandler
  {
    void SendEmail(string email, Guid machineId, Guid reservationId, string pin);
  }

  public class NotificationHandler : INotificationHandler
  {
    public void SendEmail(string email, Guid machineId, Guid reservationId, string pin)
    {
    }
  }
}
