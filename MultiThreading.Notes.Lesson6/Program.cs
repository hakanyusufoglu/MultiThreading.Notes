#region Interlocked Class
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Ortak kaynak
//        int i = 0;

//        //İ değeri 5 olur
//        Interlocked.Exchange(ref i, 5);

//        //i değeri 5 ise 10 yap
//        Interlocked.CompareExchange(ref i, 10, 5);

//        Thread thread1 = new(() =>
//        {
//            while (true)
//            {
//                //ortak kaynak olduğu için risk = i++;

//                //Senkronizasyon sağlar
//                Interlocked.Increment(ref i);
//            }
//        });

//        Thread thread2 = new(() =>
//        {
//            while (true)
//            {
//                Console.WriteLine(i++);
//            }
//        });

//        Thread thread3 = new(() =>
//        {
//            while (true)
//            {
//                //risk i--+;
//                Interlocked.Decrement(ref i);
//            }
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }
//}
#endregion
#region MemoryBarrier
internal class Program
{
    private static void Main(string[] args)
    {
        //ortak kaynak
        int i = 0;

        Thread writeThread = new(() =>
        {
            while (true)
            {
                //Senkronizasyon sağlar
                Interlocked.Increment(ref i);

                //MemoryBarrier ile tüm threadlerin aynı değere ulaşmasını sağlar
                Thread.MemoryBarrier();
            }
        });

        Thread readThread = new(() =>
        {
            while (true)
            {
                //Güncel değeri okur. Ancak MemoryBarrier nerede çağrılıcağından emin olunmalıdır
                Thread.MemoryBarrier();

                Console.WriteLine(i);
            }
        });

        writeThread.Start();
        readThread.Start();
    }
}

#endregion