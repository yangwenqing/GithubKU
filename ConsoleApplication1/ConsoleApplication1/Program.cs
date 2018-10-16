using System;

namespace program1
{
    public delegate void TimeEventHandler(object sender, TimeEventArgs args);//声明委托
    public class TimeEventArgs : EventArgs//保存参数
    {
        public int hour;
        public int minute;
        public int second;
        public TimeEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
    public class TheClock
    {
        public event TimeEventHandler AlarmClock;
        public void Alarm(int hour, int minute, int second)
        {
            TimeEventArgs myClock = new TimeEventArgs(hour, minute, second);
          
            while (true)
            {
                DateTime dt = DateTime.Now;
                if (dt.Hour.Equals(hour) && dt.Minute.Equals(minute) && dt.Second.Equals(second))
                {
                    break;
                }
            }
            AlarmClock(this, myClock);
        }
    }
    class Program
    {
        static void Main(string[] asadrgs)
        {
            TheClock aClock = new TheClock();
            Console.WriteLine("输入时间：");
            Console.Write("时刻：");
            int A = int.Parse(Console.ReadLine());
            Console.Write("分钟：");
            int B = int.Parse(Console.ReadLine());
            Console.Write("秒钟：");
            int C = int.Parse(Console.ReadLine());
            aClock.AlarmClock += ShowAlarm;
            aClock.Alarm(A, B, C);
        }
        static void ShowAlarm(object sender, TimeEventArgs args)
        {
            Console.WriteLine("TIME OVER!");
        }
    }
}

