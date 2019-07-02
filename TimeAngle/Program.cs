using System;

namespace TimeAngle
{
    public class Time
    {
        public int Hour {get; set;}
        public int Minute {get; set;}
    }
  class Program
  {
    static void Main(string[] args)
    {
        Func<Time, int> ComputeAngle = time => {
            return Math.Abs(time.Hour * 30 - time.Minute * 6);
        };
      Console.WriteLine(ComputeAngle(new Time{ Hour = 3, Minute = 27 }));
    }
  }
}