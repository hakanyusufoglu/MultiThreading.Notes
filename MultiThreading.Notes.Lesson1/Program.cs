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

//class Program
//{
//    private static void Main(string[] args)
//    {
//        //Main thread, Thread Id
//        Console.WriteLine("Main Thread");
//        Console.WriteLine(Environment.CurrentManagedThreadId);
//        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

//        Thread thread = new(() =>
//        {
//            //Worker thread, Thread Id
//            Console.WriteLine("Worker Thread");
//            Console.WriteLine(Environment.CurrentManagedThreadId);
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        });
//        thread.Start();

//        Thread thread2 = new(() =>
//        {
//            //Worker thread, Thread Id
//            Console.WriteLine("Worker Thread 2");
//            Console.WriteLine(Environment.CurrentManagedThreadId);
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        });
//        thread2.Start();
//    }
//}
#endregion

#region IsBackground Property
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        int i = 10;
//        Thread thread = new(() =>
//        {
//            while (i >= 0)
//            {
//                i--;
//                Thread.Sleep(1000);
//            }
//            Console.WriteLine("Worker Thread is completed");
//        });

//        //Varsayılan olarak false gelmektedir. True olduğunda main thread görevini tamamladığında worker thread de sonlanır. ancak false olduğunda main thread görevini tamamladığında worker thread devam eder.
//        thread.IsBackground = true;
//        thread.Start();

//        Console.WriteLine("Main Thread is completed");
//    }
//}
#endregion

#region Thread State
//class Program
//{
//Thread State işlemi tavsiye edilen bir yaklaşım değildir. Çünkü Thread State işlemi işlemciyi meşgul eder ve işlemciyi meşgul etmek performans kaybına neden olur.
//    private static void Main(string[] args)
//    {
//        int i = 10;
//        Thread thread = new(() =>
//        {
//            while (i >= 0)
//            {
//                i--;
//                Thread.Sleep(1000);
//            }
//            Console.WriteLine("Worker Thread is completed");
//        });

//        thread.Start();

//        //Threadin state bilgisini alma işlemleri

//        ThreadState state = ThreadState.Running;
//        while (true)
//        {
//            //Eğerki threadin state bilgisi Stopped ise döngüden çık
//            if (thread.ThreadState == ThreadState.Stopped)
//                break;

//            //Threadin state bilgisini almak için kullanılır. ve state değiştiğinde ekrana yazdırır.
//            if (state != thread.ThreadState)
//            {
//                state = thread.ThreadState;
//                Console.WriteLine(thread.ThreadState);
//            }
//        }

//        Console.WriteLine("Main Thread is completed");
//    }
//}
#endregion