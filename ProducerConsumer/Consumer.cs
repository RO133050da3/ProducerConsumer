using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducerConsumer
{
    class Consumer
    {
        private int _max;
        private BoundedBuffer _buffer;
        public Consumer(BoundedBuffer buf)
        {
            this._buffer = buf;
        }

        public void Run()
        {
            int temp;

            do
            {
                temp = this._buffer.Take();
            } while (temp != -1);
        }
    }
}
