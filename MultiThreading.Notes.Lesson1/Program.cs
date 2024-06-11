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

#region Locking
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        // iki threadin kullandığı i değişkeni ortak kaynağı temsil etmektedir. Bu durum race condition'a neden olacaktır. Bu durumu engellemek için lock anahtar kelimesi kullanılır. Bu da senkronizasyon işlemi sağlar.
//        int i = 1;

//        //locking için ortak nesne olarak object kullanılır. Böylelikle thread 1 işini tamamladıktan sonra thread 2 işlemine başlar. Bir yarış durumu oluşmaz.
//        object locking = new();

//        Thread thread1 = new(() =>
//        {
//            lock (locking)
//            {
//                while (i < 10)
//                {
//                    i++;
//                    Console.WriteLine($"Thread 1 : {i}");
//                }
//            }
//        });

//        Thread thread2 = new(() =>
//        {
//            lock (locking)
//            {
//                while (i > 0)
//                {
//                    i--;
//                    Console.WriteLine($"Thread 2 : {i}");
//                }
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region Sleep
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Thread thread = new(() =>
//        {
//            for (int i = 0;i < 10; i++)
//            {
//                Console.WriteLine($"Worker Thread {i}");

//                //Thread.Sleep(1000); //Thread 1 saniye durur ve işlemine devam eder. 1000ms = 1s 
//                //Thread sleep işlemi bu threadi ilgili süre kadar durdurur ancak diğer threadler çalışmaya devam eder.
//                //Thread.Sleep(0); işlemi bile cpuyu rahatlatmayı sağlar.
//                Thread.Sleep(1000);
//            }   
//        });

//        thread.Start();
//    }
//}
#endregion

#region Join
internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread = new(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker 1 Thread {i}");
            }
        });

        Thread thread2 = new(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Worker 2 Thread {i}");
            }
        });

        thread.Start();
        //Artık thread 2 çalışmaya başlamadan önce thread 1 çalışmaya başlar. Yani thread 1 tamamlandıktan sonra thread 2 çalışmaya başlar.
        thread.Join();
        thread2.Start();
    }
}
#endregion