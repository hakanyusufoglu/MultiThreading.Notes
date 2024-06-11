#region Worker Thread, Main Thread
//class Program
//{

//    //Main Thread
//    private static void Main(string[] args)
//    {

//        //Worker Thread
//        Thread thread = new((O) =>
//        {
//            for (int i = 0; i < 99; i++)
//            {
//                Console.WriteLine($"Worker Thread {i}");
//            }
//        });

//        thread.Start();

//        for (int i = 0; i < 99; i++)
//        {
//            Console.WriteLine($"Main Thread {i}");
//        } 
//    }

//}
#endregion

#region Thread Id

class Program
{
    private static void Main(string[] args)
    {
        //Main thread, Thread Id
        Console.WriteLine("Main Thread");
        Console.WriteLine(Environment.CurrentManagedThreadId);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        Thread thread = new(() =>
        {
            //Worker thread, Thread Id
            Console.WriteLine("Worker Thread");
            Console.WriteLine(Environment.CurrentManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        });
        thread.Start();

        Thread thread2 = new(() =>
        {
            //Worker thread, Thread Id
            Console.WriteLine("Worker Thread 2");
            Console.WriteLine(Environment.CurrentManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        });
        thread2.Start();
    }
}
#endregion
