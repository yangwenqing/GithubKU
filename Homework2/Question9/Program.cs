using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] score;
            score = new int[97];
            for(int i=0;i<97;i++)
            {
                score[i] = i + 3;
            }
            for(int i=2;i<100;i++)
            {
                for(int j=0;j<97;j++)
                {
                    if(score[j]%i==0&&score[j]!=i)
                    {
                        score[j] = 0;
                    }
                }
            }
            for(int i=0;i<97;i++)
            {
                if(score[i]!=0)
                {
                    Console.Write(score[i]+" ");
                }

            }
        }
    }
}
