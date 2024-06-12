#region Spinning
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

internal class Program
{
    private static void Main(string[] args)
    {
        //Ortak kaynak üzerinde işlem yaparken bir threadin diğer threadin işlemine müdahale etmemesi için Monitor.Enter ve Monitor.Exit kullanılır.
        //Monitor.Enter ve Monitor.Exit kullanıldığında bir thread bir kaynağı işgal ettiğinde diğer thread o kaynağı işgal edemez.

        //Monitor enter ve exit kullanıldığında bir hata meydana geldiğinde kaynak serbest bırakılmayacaktır. hatanın alındığı yeerde monitor exit kullanılmalıdır. Bu durum için finnaly bloğu kullanılabilir.

        //Lock mekanizması bu durumu otomatik olarak yapar. Yani kaynağı işgal eden thread işini bitirdiğinde kaynağı serbest bırakır. Monitor enter ve exit kullanıldığında bu işlemi manuel olarak yapmak gerekir.

        //Ortak kaynak
        int i = 0;

        object locking = new();

        Thread thread1 = new(() =>
        {
            try
            {
                Monitor.Enter(locking);

                for (i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread 1 {i}");
                }
            }
            finally
            {
                Monitor.Exit(locking);
            }

        });

        Thread thread2 = new(() =>
        {
            try
            {
                Monitor.Enter(locking);

                for (i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread 2 {i}");
                }
            }
            finally
            {
                Monitor.Exit(locking);
            }
        });

        thread1.Start();
        thread2.Start();
    }
}
#endregion