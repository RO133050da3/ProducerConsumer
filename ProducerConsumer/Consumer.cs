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
        public Consumer(BoundedBuffer buf, int howMany)
        {
            this._max = howMany;
            this._buffer = buf;
        }

        public void Run()
        {
            for (int i = 0; i < this._max; i++)
            {
               
                int temp = this._buffer.Take();
                
                
            }
        }
    }
}
