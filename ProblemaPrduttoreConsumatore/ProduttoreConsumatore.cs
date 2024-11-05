using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblemaPrduttoreConsumatore
{
    public class ProduttoreConsumatore
    {
        private readonly object Lock = new object();
        private Queue<int> Queue = new Queue<int>();
        private int counter = 0;
        private int limit = 5000;

        private int QueueLength = 50;

        public void Run() {

            Thread t1 = new Thread(() => { Produce(); });
            Thread t2 = new Thread(() => { Consume(); });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("END");
            Console.ReadKey();
        }

        public void Produce()
        {
            while (counter < limit)
            {
                lock (Lock)
                {                
                    if (Queue.Count <= QueueLength)
                    {
                        Queue.Enqueue(counter++);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Producttore:" + Queue.Count);
                        Console.ForegroundColor = ConsoleColor.White;                        
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Producttore: Full" + counter);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    //Thread.Sleep(100);
                }
            }
        }

        public void Consume()
        {
            while (counter < limit)
            {
                lock (Lock)
                {
                    if (Queue.Count > 0)
                    {
                        int v = Queue.Dequeue();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Consumatore:" + Queue.Count);
                        Console.ForegroundColor = ConsoleColor.White;                        
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Consumatore: Empty" + counter);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    //Thread.Sleep(300);
                }
            }
        }
    }
}
