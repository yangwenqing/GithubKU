using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = "";
            Console.Write("Please input your array length:");
            s = Console.ReadLine();
            int length = Int32.Parse(s);
            int [] score;
            score = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write("请输入元素:");
                    s = Console.ReadLine();
                  int  number = Int32.Parse(s);
                    score[i] = number;
                }
            int sum = 0;
            double average = 0;
            int max = score[0];
            int min = score[0];
            for (int i=0;i<length;i++)
            {
                if (max < score[i])
                    max = score[i];
                if (min > score[i])
                    min = score[i];
                sum += score[i];
                average = sum /( i+1);
            }
            Console.WriteLine("最大值为:"+max);
            Console.WriteLine("最小值为:" + min);
            Console.WriteLine("和为:" + sum);
            Console.WriteLine("平均数为:" + average);
        }
    }
}
