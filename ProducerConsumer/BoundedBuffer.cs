using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _q;
        private bool _lastItemServed = false;

        private int _max;
        public BoundedBuffer(int capacity)
        {
            this._max = capacity;
            this._q = new Queue<int>(capacity);
        }

        public bool IsFull()
        {
            if (this._q.Count < this._max)
            {
                return false;
            }

            return true;
        }

        public void Put(int element)
        {
            lock (this._q)
            {
                while (this.IsFull())
                {
                    Monitor.Wait(this._q);
                }


                // Insert the element into the queue
                this._q.Enqueue(element);
                Console.WriteLine("Just added {0} into the buffer from thread {1}.", element, Thread.CurrentThread.ManagedThreadId);
                Monitor.PulseAll(this._q);

            }

        }

        public int Take()
        {
            lock (this._q)
            {
                if (this._lastItemServed)
                {
                    return -1;
                }

                while (this._q.Count == 0)
                {
                    // Wait until the queue is not empty
                    Monitor.Wait(this._q); // thread A is waiting
                    if (this._lastItemServed)
                    {
                        return -1;
                    }
                }

                int temp = this._q.Dequeue();
                Console.WriteLine("Just took {0} from the buffer from thread {1}.", temp, Thread.CurrentThread.ManagedThreadId);
                Monitor.PulseAll(this._q);
                if (temp == -1)
                {
                    this._lastItemServed = true;
                }
                return temp;
            }
        }
    }
}
