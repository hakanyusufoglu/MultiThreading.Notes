#region Spinlock
//internal class Program
//{
//    //Spinlock: birden fazla thread ile senkronizasyon sağlamak için kullanılır.
//    private static void Main(string[] args)
//    {
//        //Ortak kaynak
//        int value = 0;

//        SpinLock spinLock = new();


//        Thread thread1 = new(() =>
//                {
//                    bool lackTaken = false;
//                    try
//                    {
//                        spinLock.Enter(ref lackTaken);
//                        if (lackTaken)
//                            for (int i = 0; i < 999; i++)
//                                Console.WriteLine($"Thread1 : {++value}");
//                    }
//                    finally
//                    {
//                        spinLock.Exit();
//                    }

//                });

//        Thread thread2 = new(() =>
//        {
//            bool lackTaken = false;
//            try
//            {
//                spinLock.Enter(ref lackTaken);
//                if (lackTaken)
//                    for (int i = 0; i < 999; i++)
//                        Console.WriteLine($"Thread2 : {value--}");
//            }
//            finally
//            {
//                spinLock.Exit();
//            }

//        });
//        thread1.Start();
//        thread2.Start();

//    }
//}
#endregion

#region SpinWait

internal class Program
{
    //SpinWait: SpinLock ile aynı işlevi görür. Fakat SpinWait daha performanslıdır.
    private static void Main(string[] args)
    {
        bool waitMod = false, condition = false;

        Thread thread1 = new(() =>
        {
            while (true)
            {
                if(waitMod)
                {
                    continue;
                }
                if (!condition)
                {
                    continue;
                }

                Console.WriteLine("Thread1 işleniyor...");
            }
        });

        //Thread1'in idealize halidir.
        Thread thread2 = new(() =>
        {
            while (true)
            {
                SpinWait.SpinUntil(() =>
                {
                    Thread.MemoryBarrier();
                    //return geçerli olmadığı sürece Thread2 işleniyor deme
                    return waitMod || !condition;
                });


                Console.WriteLine("Thread2 işleniyor...");
            }
        });
        thread1.Start();
        thread2.Start();
    }
}

#endregion