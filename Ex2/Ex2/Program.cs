using System;
using System.Threading;

class Program
{
    static readonly object _object = new object();
    static int v = 0;
   
    static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            new Thread(Locks).Start();
        }
        new Thread(() =>
        {
            Thread.Sleep(10000);
            Console.WriteLine("Wartość: " + v);
        }).Start();
        Console.ReadKey();
    }
    static void Locks()
    {
        lock (_object)
        {
            v += 10;
            Thread.Sleep(10000);
        }
    }
}