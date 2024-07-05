
#region AutoResetEvent
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //Örneğin thread1 işlemini bitirdikten sonra thread2 işlemi başlamasını istiyorsak EventWaitHandle kullanabiliriz.
//        //AutoReset her zaman otomatik olarak resetlenir bunun faydası ise bir thread işlemi bittiğinde diğer thread işlemi başlar.
//        //Her bir thread kuyruğa alınır ve sırayla işlem yaparlar.
//        AutoResetEvent autoResetEvent = new(false);

//        Thread thread1 = new(() =>
//{
//    Console.WriteLine("Thread1");

//    //Thread1 işlemi bittiğinde autoResetEvent.Set() metodu ile thread2 işlemine geçiş yapılmasını sağlıyoruz.
//    //Bekleyen threadlerden sadece bir tanesi başlatılır.
//    autoResetEvent.Set();
//});

//Thread thread2 = new(() =>
//{
//    //Thread1 işlemi bittikten sonra thread2 işlemi başlar. thread2 şuan beklemesini sağlıyoruz.
//    autoResetEvent.WaitOne();
//    Console.WriteLine("Thread2");

//    autoResetEvent.Set();
//});

//Thread thread3 = new(() =>
//{
//    //Thread1 işlemi bittikten sonra thread2 işlemi başlar. thread2 şuan beklemesini sağlıyoruz.
//    autoResetEvent.WaitOne();
//    Console.WriteLine("Thread3");


//    autoResetEvent.Set();
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
//    }
//}
#endregion

#region ManualResetEventSlim
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        //ManualResetEventSlim ile AutoResetEvent arasındaki fark ise ManualResetEventSlim ile birden fazla thread işlemi başlatılabilir.
//        ManualResetEventSlim manualResetEventSlim = new(false);

//        Thread thread1 = new(() =>
//        {
//            Console.WriteLine("Thread1");

//            //Set komutu ile diğer threadlerin işlem yapmasını sağlıyoruz.
//            manualResetEventSlim.Set();


//        });

//        Thread thread2 = new(() =>
//        {

//            for (int i = 0; i < 5; i++)
//            {
//                manualResetEventSlim.Wait();

//                Console.WriteLine("Thread2");

//                //Reset komutu ile diğer threadlerin işlem yapmasını engelliyoruz. Diğer threadler işlem yapamaz.
//                manualResetEventSlim.Reset();
//            }
//        });

//        Thread thread3 = new(() =>
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                manualResetEventSlim.Wait();
//                Console.WriteLine("Thread3");

//                manualResetEventSlim.Reset();

//            }
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }
//}
#endregion

#region EventWaitHandle
internal class Program
{
    private static void Main(string[] args)
    {

        //EventWaitHandle, AutoResetEvent ve ManuelEvenetResetSlim'in birleşimini düşünebiliriz. Ortak bir isimlendirme yapmasını sağlar. Örneğin AutoResetEvent da WaitOne ve Set metotları vardır. ManuelResetEventSlim de Wait ve Set metotları vardır. EventWaitHandle bu metotları ortak hale getirir.

        //EventWaitHandle eventWaitHandle = new(false, EventResetMode.AutoReset);
        EventWaitHandle eventWaitHandle = new(false, EventResetMode.ManualReset);

        Thread thread1 = new(() =>
        {
            Console.WriteLine("Thread1");

            //Set komutu ile diğer threadlerin işlem yapmasını sağlıyoruz.
            eventWaitHandle.Set();


        });

        Thread thread2 = new(() =>
        {
            eventWaitHandle.WaitOne();
            Console.WriteLine("Thread2");
        });

        Thread thread3 = new(() =>
        {
            eventWaitHandle.WaitOne();
            Console.WriteLine("Thread3");

        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}
#endregion