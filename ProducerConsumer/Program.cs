using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            BoundedBuffer buf = new BoundedBuffer(4);

            Producer prod = new Producer(buf, 1000);
            Consumer con = new Consumer(buf, 1000);

            Parallel.Invoke(prod.Run, con.Run);


            //Console.ReadKey();
            Console.WriteLine("The buffer was filled {0} times.", buf.NumberOfFills);
            Console.ReadKey();
        }
    }
}
