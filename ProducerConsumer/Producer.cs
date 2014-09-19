using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        private int _max;
        private BoundedBuffer _buffer;

        public Producer(BoundedBuffer buffer, int howManyToProduce)
        {
            this._max = howManyToProduce;
            this._buffer = buffer;
        }

        public void Run()
        {
            for (int i = 0; i < this._max; i++)
            {
                
                this._buffer.Put(i);
                
                
            }
        }
    }
}
