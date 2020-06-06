using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFor2020
// работаем с параллельными вычислениями. Создаем консольное приложение
// задача: в качестве вычислений находим сумму . Напишем 2 класса.
// будет два подпроцесса, причем 1 будет параллельными вычислениями находить.
// посчитаем, сколько времени понадобилось для последов. суммы и для параллельных вычислений
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); // таймер
            Summator s = new Summator(); 
            sw.Start(); 
            s.Summ();
            sw.Stop();
            Console.WriteLine("Последовательная сумма: {0}", s.Result);
            Console.WriteLine("Вычисления заняли {0} мс.", sw.ElapsedMilliseconds);
            ParallelSummator ps = new ParallelSummator();
            sw.Reset();
            sw.Start();
            ps.Summ();
            sw.Stop();
            Console.WriteLine("Параллельная сумма: {0}", ps.Result);
            Console.WriteLine("Вычисления заняли {0} мс.", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
