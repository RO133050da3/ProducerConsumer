using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue;
        private int _cap;
        private bool _haveServeLastElement = false;
        public int NumberOfFills = 0;

        public BoundedBuffer(int capacity)
        {
            this._cap = capacity;
            this._queue = new Queue<int>();
        }

        public bool IsFull()
        {
            if (this._queue.Count >= this._cap)
            {
                //Console.WriteLine("Buffer full!");
                this.NumberOfFills ++;
                return true;
            }

            return false;
        }

        public void Put(int element)
        {
            lock (this._queue)
            {
                while (this.IsFull())
                {
                    // Wait until the buffer is not full anymore
                    Monitor.Wait(this._queue);
                }
                this._queue.Enqueue(element);
                Console.WriteLine("The value {0} was added to the buffer on thread >X<", element);
                Monitor.PulseAll(this._queue);
            }
        }

        public int Take()
        {
            lock (this._queue)
            {
                if (this._haveServeLastElement)
                {
                    return -1;
                } 
                
                while (this._queue.Count == 0)
                {
                    // Wait while the queue is empty
                    Monitor.Wait(this._queue);

                    if (this._haveServeLastElement)
                    {
                        return -1;
                    } 
                }

                

                int temp = this._queue.Dequeue();
              
                if (temp == -1)
                {
                    this._haveServeLastElement = true;
                }
                Console.WriteLine("Element {0} was just removed from the buffer", temp);
                Monitor.PulseAll(this._queue);
                return temp;
            }
        }
    }
}
