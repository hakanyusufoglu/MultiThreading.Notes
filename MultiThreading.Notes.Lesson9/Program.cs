
#region AutoResetEvent
internal class Program
{
    private static void Main(string[] args)
    {
        //Örneğin thread1 işlemini bitirdikten sonra thread2 işlemi başlamasını istiyorsak EventWaitHandle kullanabiliriz.
        //AutoReset her zaman otomatik olarak resetlenir bunun faydası ise bir thread işlemi bittiğinde diğer thread işlemi başlar.
        //Her bir thread kuyruğa alınır ve sırayla işlem yaparlar.
        AutoResetEvent autoResetEvent = new(false);

        Thread thread1 = new(() =>
        {
            Console.WriteLine("Thread1");

            //Thread1 işlemi bittiğinde autoResetEvent.Set() metodu ile thread2 işlemine geçiş yapılmasını sağlıyoruz.
            //Bekleyen threadlerden sadece bir tanesi başlatılır.
            autoResetEvent.Set();
        });

        Thread thread2 = new(() =>
        {
            //Thread1 işlemi bittikten sonra thread2 işlemi başlar. thread2 şuan beklemesini sağlıyoruz.
            autoResetEvent.WaitOne();
            Console.WriteLine("Thread2");

            autoResetEvent.Set();
        });

        Thread thread3 = new(() =>
        {
            //Thread1 işlemi bittikten sonra thread2 işlemi başlar. thread2 şuan beklemesini sağlıyoruz.
            autoResetEvent.WaitOne();
            Console.WriteLine("Thread3");


            autoResetEvent.Set();
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}

#endregion