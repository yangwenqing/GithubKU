using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class Program
    {
      static Boolean Sushu(int n)//判断素数
        {
            for(int i =2;i<n;i++)
            {
                if (n % i == 0)
                    goto Outer;
            }
            return true;
            Outer: return false;
        }
        static void Main(string[] args)
        {
            string s = "";
            Console.Write("Please input a number:");
            s = Console.ReadLine();
            int Mynumber = Int32.Parse(s);

            if (Sushu(Mynumber) == true)
            {
                Console.WriteLine(Mynumber);
            }
            for (int i = 2; i < Mynumber; i++)
            {
                if (Mynumber % i == 0)
                {
                    if (i == 2)
                    {
                        Console.Write(i + " ");
                    }
                    else
                    {
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0)
                                goto Out;
                        }
                        Console.Write(i + " ");
                        Out:;
                    }
                }
            }
        }
    }
}
