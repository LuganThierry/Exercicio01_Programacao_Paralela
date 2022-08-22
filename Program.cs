using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.CodeDom;

namespace TP.Aula07Exer01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ParallelOptions threadNum = new ParallelOptions();
            threadNum.MaxDegreeOfParallelism = 7;

            List<int> apiNumerica = new List<int>();

            for(int i = 0; i < 99; i++)
            {
                apiNumerica.Add(i);
            }

            Stopwatch cronometro = new Stopwatch();

            cronometro.Start();


            Parallel.For(0, apiNumerica.Count, threadNum, i =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"API de ID {i} evocada com sucesso. Tempo de evocação: {cronometro.Elapsed}. Thread responsável: {Thread.CurrentThread.ManagedThreadId}");
            });


            cronometro.Stop();

            Console.WriteLine($"Tempo total: {(cronometro.ElapsedMilliseconds) / 1000} segundos");

            Console.ReadKey();

        }

    }
}
