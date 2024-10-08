﻿#region Spinning
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Spinning belli bir koşul sağlandığında döngüden çıkılması gereken durumlarda kullanılır.
//        //Şartla bir threadin içerisinde döngü oluşturulur ve bu döngüde bir koşul sağlandığında döngüden çıkılır.
//        //Sürekli olarak işlemciyi meşgul eder ve performans kaybına neden olur. Çünkü while döngüsü sürekli olarak çalışır ve işlemciyi meşgul eder.
//        bool threadCondition = true;

//        Thread thread1 = new(() =>
//        {
//            while (true)
//            {
//                if (threadCondition)
//                {
//                    for (int i = 0; i < 10; i++)
//                    {
//                        Console.WriteLine($"Thread 1 {i}");
//                    }

//                    threadCondition = false;
//                    break;
//                }
//            }
//        });

//        Thread thread2 = new(() =>
//        {
//            while (true)
//            {
//                if (!threadCondition)
//                {
//                    for (int i = 10; i > 0; i--)
//                    {
//                        Console.WriteLine($"Thread 2 {i}");
//                    }

//                    break;
//                }
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region Monitor.Enter ve Monitor.Exit
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Ortak kaynak üzerinde işlem yaparken bir threadin diğer threadin işlemine müdahale etmemesi için Monitor.Enter ve Monitor.Exit kullanılır.
//        //Monitor.Enter ve Monitor.Exit kullanıldığında bir thread bir kaynağı işgal ettiğinde diğer thread o kaynağı işgal edemez.

//        //Monitor enter ve exit kullanıldığında bir hata meydana geldiğinde kaynak serbest bırakılmayacaktır. hatanın alındığı yeerde monitor exit kullanılmalıdır. Bu durum için finnaly bloğu kullanılabilir.

//        //Lock mekanizması bu durumu otomatik olarak yapar. Yani kaynağı işgal eden thread işini bitirdiğinde kaynağı serbest bırakır. Monitor enter ve exit kullanıldığında bu işlemi manuel olarak yapmak gerekir.

//        //Ortak kaynak
//        int i = 0;

//        object locking = new();

//        Thread thread1 = new(() =>
//        {
//            try
//            {
//                Monitor.Enter(locking);

//                for (i = 0; i < 10; i++)
//                {
//                    Console.WriteLine($"Thread 1 {i}");
//                }
//            }
//            finally
//            {
//                Monitor.Exit(locking);
//            }

//        });

//        Thread thread2 = new(() =>
//        {
//            try
//            {
//                Monitor.Enter(locking);

//                for (i = 0; i < 10; i++)
//                {
//                    Console.WriteLine($"Thread 2 {i}");
//                }
//            }
//            finally
//            {
//                Monitor.Exit(locking);
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region LockTaken
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //lockToken parametresi: lock mekanizmasının işlemi başarılı bir şekilde gerçekleşip gerçekleşmediğini kontrol eder. Çünkü Monitor.Enter ve Monitor.Exit lock işleminin başarılı bir şekilde gerçekleştiğinin garantisini vermemektedir.

//        //Ortak kaynak
//        int i = 0;

//        object locking = new();

//        Thread thread1 = new(() =>
//        {
//            try
//            {
//                bool lockTaken = false;
//                Monitor.Enter(locking, ref lockTaken);

//                if (lockTaken)
//                    for (i = 0; i < 10; i++)
//                        Console.WriteLine($"Thread 1 {i}");
//            }
//            finally
//            {
//                Monitor.Exit(locking);
//            }

//        });

//        Thread thread2 = new(() =>
//        {
//            try
//            {
//                bool lockTaken = false;
//                Monitor.Enter(locking, ref lockTaken);

//                if (lockTaken)
//                    for (i = 0; i < 10; i++)
//                        Console.WriteLine($"Thread 2 {i}");
//            }
//            finally
//            {
//                Monitor.Exit(locking);
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region Monitor.TryEnter
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Monitor.TryEnter 
//        //Ortak kaynak
//        int i = 0;

//        object locking = new();

//        Thread thread1 = new(() =>
//        {
//            //Monitor.TryEnter kullanıldığında belirli bir süre içerisinde kaynağı işgal edemezse işlemi iptal eder.
//            var result = Monitor.TryEnter(locking, 20);
//            if (result)
//            {
//                try
//                {


//                    for (i = 0; i < 10; i++)
//                        Console.WriteLine($"Thread 1 {i}");
//                }
//                finally
//                {
//                    Monitor.Exit(locking);
//                }
//            }

//        });

//        Thread thread2 = new(() =>
//        {
//            //Monitor.TryEnter kullanıldığında belirli bir süre içerisinde kaynağı işgal edemezse işlemi iptal eder.
//            var result = Monitor.TryEnter(locking, 1);
//            if (result)
//            {
//                try
//                {


//                    for (i = 0; i < 10; i++)
//                        Console.WriteLine($"Thread 2 {i}");
//                }
//                finally
//                {
//                    Monitor.Exit(locking);
//                }
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region Mutex Class
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Mutex sınıfı : Monitor sınıfının daha gelişmiş bir versiyonudur. Monitor sınıfı sadece aynı uygulama içerisindeki threadler arasında kullanılabilirken Mutex sınıfı farklı uygulamalar (processler) arasında da kullanılabilir.
//        Mutex mutex = new();
//        Thread thread1 = new(() =>
//        {
//            //Mutex sınıfı ile bir kaynağı işgal ettiğimizde o kaynağı işgal eden thread dışındaki diğer threadler o kaynağı işgal edemez.
//            //mutex.WaitOne() ile bir kaynağı işgal ederken mutex.ReleaseMutex() ile o kaynağı serbest bırakırız.
//            mutex.WaitOne();

//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 1 {i}");
//            }

//            mutex.ReleaseMutex();
//        });


//        Thread thread2 = new(() =>
//        {
//            mutex.WaitOne();

//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 2 {i}");
//            }

//            mutex.ReleaseMutex();
//        });

//        thread1.Start();
//        thread2.Start();
//    }
//}
#endregion

#region Single Instance Application with Mutex
internal class Program
{
    static Mutex _mutex;
    static string _programName = "Example Project Name";
    private static void Main(string[] args)
    {
        Mutex.TryOpenExisting(_programName, out _mutex);

        if (_mutex is null)
        {
            _mutex=new Mutex(true,_programName);

            Console.WriteLine("Program is running..."); ;
            Console.Read();
        }
        else
        {
            //mutex nesnesi varsa ilgili mutexi kapat.
            _mutex.Close();
            return;
        }
    }
}
#endregion