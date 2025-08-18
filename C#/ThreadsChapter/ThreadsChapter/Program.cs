using System.Threading;

/*
Console.WriteLine("Hello World 1");
Thread.Sleep(1000);
Console.WriteLine("Hello World 2");
Thread.Sleep(1000);
Console.WriteLine("Hello World 3");
Thread.Sleep(1000);
Console.WriteLine("Hello World 4");
Thread.Sleep(1000);
Console.WriteLine("Hello World 5");
*/

/*
new Thread(() => 
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 1");
}).Start();
new Thread(() => 
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 2");
}).Start();
new Thread(() => 
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 3");
}).Start();
new Thread(() => 
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 4");
}).Start();
new Thread(() => 
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 5");
}).Start();
*/


/*
  Enumerable.Range(1, 1000).ToList().ForEach(f =>
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " started");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " finished");

            });
        });
        Console.ReadLine();
 */

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Main Thread Started");
        Thread thread1 = new Thread(Thread1Function);
        Thread thread2 = new Thread(Thread2Function);
        thread1.Start();
        thread2.Start();

        //thread1.Join();
        //Console.WriteLine("Thread1Function done");
        if (thread1.Join(1000))
        {
            Console.WriteLine("Thread1Function done");
        }
        else
        {
            Console.WriteLine("Thread1Function wasn't done within 1 second.");
        }
        thread2.Join();
        Console.WriteLine("Thread2Function done");

        if (thread1.IsAlive)
        {
            Console.WriteLine("Thread is still doing stuff.");
        }
        else
        {
            Console.WriteLine("Thread one is done.");
        }

        Console.WriteLine("Main Thread Ended");
    }

    public static void Thread1Function()
    {
        Console.WriteLine("Thread1Function started");
        Thread.Sleep(3000);
        Console.WriteLine("Thread1Function coming back to Main");
    }
    public static void Thread2Function()
    {
        Console.WriteLine("Thread2Function started");
    }
}