using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.Write("Please input numberone:");
            s = Console.ReadLine();
            int a = Int32.Parse(s);
            Console.Write("Please input numbertwo:");
            s = Console.ReadLine();
            int b = Int32.Parse(s);
            Console.Write("所求的积为:{0}", a * b);
        }
    }
}