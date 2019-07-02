using System;
using Hangfire;
using Hangfire.MemoryStorage;

namespace HangfireInMem
{
  class Program
  {
    static void Main(string[] args)
    {
      GlobalConfiguration.Configuration.UseMemoryStorage();

      using (new BackgroundJobServer())
      {
        RecurringJob.AddOrUpdate(() => Routine(), Cron.Hourly);
        Console.ReadKey();
      }
    }

    public static void Routine()
    {
      var time = DateTime.Now;
      Console.WriteLine($"Recurring at {time}.");
    }
  }
}
