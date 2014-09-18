using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _buf;

        private int _max;
        public BoundedBuffer(int capacity)
        {
            this._max = capacity;
            this._buf = new Queue<int>(capacity);
        }

        public void Put(int element)
        {
            if (this._buf.Count < this._max)
            {
                // Insert the element into the queue
            }

        }
    }
}
