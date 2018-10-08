using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Question1
{ 
  public class TimeClock
    {
        public delegate void ClockEventHandler();
        public event ClockEventHandler timing;
        public void TimeControl(DateTime time)
        {
            while(true)
            {
                DateTime time0 = DateTime.Now;
                if(time0>=time)
                {
                    timing();
                    break;
                }
            }

        }
    }
    public class ShowTime
    {
        public void printout()
        {
            Console.WriteLine("Time is over.");
        }
    }

   public class program
    { 
        static void Main(string[] args)
        {
            var e = new TimeClock();
            var showtime = new ShowTime();
            string s = "";
            Console.WriteLine("Please input your datatime by the form of:2018-10-8 18:00:00");
            s = Console.ReadLine();
            DateTime time1 = System.Convert.ToDateTime(s);
            e.timing += new TimeClock.ClockEventHandler(showtime.printout);
            e.TimeControl(time1);
           
        }
    }
}
