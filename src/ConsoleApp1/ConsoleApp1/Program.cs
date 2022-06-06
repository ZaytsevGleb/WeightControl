using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using static System.Threading.Thread;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadId {0}",Thread.CurrentThread.ManagedThreadId);
            MyClass my = new MyClass();
            my.OperationAsync();
            Console.ReadKey();
        }
    }

    class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation threadID {0}",CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            Task task = new Task(Operation);
            task.Start();
            await task;
        }
    }
}