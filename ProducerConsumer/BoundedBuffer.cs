﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _q;

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
                Console.WriteLine("Just added {0} into the buffer.", element);
                Monitor.PulseAll(this._q);
                
            }

        }

        public int Take()
        {
            lock (this._q)
            {
                while (this._q.Count == 0)
                {
                    // Wait until the queue is not empty
                    Monitor.Wait(this._q);
                }
            
                int temp = this._q.Dequeue();
                Console.WriteLine("Just took {0} from the buffer.", temp);
                Monitor.PulseAll(this._q);
                return temp;
            }   
        }
    }
}
