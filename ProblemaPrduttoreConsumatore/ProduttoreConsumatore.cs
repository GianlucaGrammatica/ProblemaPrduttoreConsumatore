using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblemaPrduttoreConsumatore
{
    internal class ProduttoreConsumatore
    {
        private readonly object Lock = new object();
        private Queue<int> Queue = new Queue<int>();

        private int QueueLength = 4;

        public void Produce(int Input)
        {
            lock (Lock) {

                if (Queue.Count <= QueueLength)
                {
                    Queue.Enqueue(Input);
                }
                else
                {
                    Monitor.Wait(Lock);
                }

                Monitor.Pulse(Lock);
            }
        }

        public void Consume()
        {
            lock(Lock)
            {
                while (!Queue.Any())
                {
                    Monitor.Wait(Lock);
                }

                Queue.Dequeue();

                Monitor.Pulse(Lock);
            }
        }
    }
}
