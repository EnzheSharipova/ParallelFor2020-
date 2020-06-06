using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFor2020
{
    // последовательное вычисление
    class Summator
    {
        private int N = 1677721600;
        public long Result { get; private set; }

        public Summator()
        {
            Result = 0;
        }
        public void Summ()
        {
            long s = 0;
            for (int i = 1; i <= N; i++)
            {
                s += 1;
            }
            Result = s;
        }
    }

}
