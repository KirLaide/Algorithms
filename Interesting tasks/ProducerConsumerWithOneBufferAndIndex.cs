using System;
using System.Threading;


//Producr / Consumer problem with one fixed buffer And index
namespace ProducerConsumer
{
    public class IntBuffer
    {
        private int index;
        public const int  SizeOfBuffer = 8;
        private int[] buffer = new int[SizeOfBuffer];
        Object locker = new Object();
        
        public void add(int num)
        {
            lock(locker)
            {
                while (index <= buffer.Length - 1)
                {
                   buffer[index++] = num;
                   return;
                }
            }
            
        }

        public int remove()
        {
            lock (locker)
            {
                while (index >= 1)
                {
                    if (index <= buffer.Length)
                    {
                        int ret = buffer[--index];
                        return ret;
                    }
                }
            }
            return 0;
        }
    }
    
    public class Producer
    {
        private IntBuffer buffer;

        public Producer(IntBuffer buffer)
        {
            this.buffer = buffer;
        }

        public void run()
        {
            Random r = new Random();
            while (true)
            {
                int num = r.Next();
                buffer.add(num);
                Console.WriteLine("Producer " + num);
            }
        }
    }

    public class Consumer
    {
        private IntBuffer buffer;

        public Consumer(IntBuffer buffer)
        {
            this.buffer = buffer;
        }

        public void run()
        {
            while (true)
            {
                int num = buffer.remove();
                if (num != 0)
                {
                    Console.WriteLine("Consumer " + num);
                }
                
            }
        }
    }

    public class Program
    {
        
        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadLine();
        }

        
        void Run()
        {
            IntBuffer b = new IntBuffer();

            Producer p = new Producer(b);
            Thread threadProducer = new Thread(p.run);
           
            Consumer c = new Consumer(b);
            Thread threadConsumer = new Thread(c.run);
            
            threadProducer.Start();
            threadConsumer.Start();


        }
    }
    
}
