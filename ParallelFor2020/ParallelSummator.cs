using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor2020
{
    // параллельное вычислениедим частями, для этого берем 
    // партс= число частей
   
    class ParallelSummator
    {
        private int N = 1677721600;
        private class Sum // еще один класс
        {
            public long value;
        }
        private Sum res;
        public long Result // свойство 
        {
            get { return res.value; }
            private set { res.value = value; } 
        }

        private int parts = 4; // число кусков кода, 
        //число процессоров, 4 -число ядер:)

        public ParallelSummator() // конструктор, назв совпадает с нзв класса
        {
            res = new Sum(); // для подпроцесса, когда в цикле подсумму вычисляем
            Result = 0; // обнуляем результат
        }

        private void _Summ(int part) // функция? 
        {
            // 0 1 2 3 4 5 6 | 7 8  9 10 11 12
            // 1 2 3 4 5 6 7 | 8 9 10 11 12 13
            int partsSize = (int) N / parts; //3
            int ost = N - partsSize * parts; //2
            int st = part * partsSize + ((part<ost)?part:ost);
            int fn = (part+1)*partsSize + ((part+1<ost)?part:(ost-1));
            long s = 0;
            for (int i = st; i <= fn; i++)
            {
                // суммирую в локальной переменной
                s += 1;
            }
            // поскольку у нас параллельные процессы, сразу к 
            // результату добавить число не можем. 
            // внутри подпроцессов нужно установить мониторинг
            // но внутри цикла делать не смоит!!

            Monitor.Enter(res); // сюда добавить Result добавить не можем
            // поэтому в начале заводим объект res
            try
            {
                Result += s;
            }
            finally
            {
                Monitor.Exit(res);
            }
        }

        public void Summ() // метод суммирования
        {
            Parallel.For( // клас параллель для создания 
         // параллельного цикла
         // цикл итераций которого могут 
         //выполняться одновременно
                0, // начальное значение
                parts,  // число частей, не включительно 4:) т.е от 0 до3 включительно
                new Action<int>(_Summ) // делегат, точнее функция, присвоенная делегату
            // каждая итерация может начинаться в произвольном порядке
                );
        }
    }
}
