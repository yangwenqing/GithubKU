using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.Write("Please input a number:");
            s = Console.ReadLine();
            int Mynumber = Int32.Parse(s);
            int a = Mynumber;
            for (int i = 2; i <a; i++)
            {
              while(Mynumber % i == 0 && i != Mynumber)
                {
                    Console.Write(i + " ");
                    Mynumber = Mynumber / i;
                }
              while (Mynumber % i == 0 && i == Mynumber)
                { 
                    Console.Write(i + " ");
                    Mynumber = Mynumber / i;
                }
            }
       

        }
    }
}
