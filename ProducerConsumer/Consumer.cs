using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducerConsumer
{
    class Consumer
    {
        private BoundedBuffer _buffer;

        public Consumer(BoundedBuffer buffer)
        {
            this._buffer = buffer;
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
