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

        public Consumer(BoundedBuffer buffer, int expectedAmount)
        {
            this._buffer = buffer;
            this._max = expectedAmount;
        }

        public void Run()
        {
            for (int i = 0; i < this._max; i++)
            {
                int temp = this._buffer.Take();
                Console.WriteLine("Consumer just took {0} from the buffer", temp);
            }
        }
    }
}
