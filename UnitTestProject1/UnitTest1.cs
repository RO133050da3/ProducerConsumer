﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProducerConsumer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BoundedBuffer buf = new BoundedBuffer(4);

            Producer prod = new Producer(buf, 10);
            Consumer con = new Consumer(buf, 10);

            Parallel.Invoke(prod.Run, con.Run);
        }
    }
}
