using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue;
        private int _cap;

        public BoundedBuffer(int capacity)
        {
            this._cap = capacity;
            this._queue = new Queue<int>();
        }

        public Boolean IsFull()
        {
            return true;
        }

        public void Put(int element)
        {
            this._queue.Enqueue(element);
        }

        public int Take()
        {
            int temp = this._queue.Dequeue();
            return temp;
        }
    }
}
