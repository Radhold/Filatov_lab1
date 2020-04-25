using System;
using System.Diagnostics;

namespace lab1_Filatov
{
    class Program
    {
        static void Main(string[] args)
        {
            uint N = 10;
            //for (int k=0;k<10;k++)
           // { 
                var sw = new Stopwatch();
                Stack myStack = new Stack(N);
                for (uint i = myStack.Size; i < myStack.array.Length; ++i)
                {
                    myStack.Push(new Random().Next() % 1000); 
                }
            myStack.Print();
                sw.Start();
                myStack.BubbleSort();
                sw.Stop();
         //   Console.WriteLine(
         //        $"Номер сортировки: {k + 1,-2} Колличество отсортированных элементов: {N,-4} Время сортировки (ms): {sw.ElapsedMilliseconds,-4} Кол-личество операций (N_op): {Stack.N_op}");
            myStack.Print();
            N += 300;
                Stack.N_op = 0;
            }

        }
    }
//}
