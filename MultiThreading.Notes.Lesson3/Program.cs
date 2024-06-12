#region Spinning
internal class Program
{
    private static void Main(string[] args)
    {
        //Spinning belli bir koşul sağlandığında döngüden çıkılması gereken durumlarda kullanılır.
        //Şartla bir threadin içerisinde döngü oluşturulur ve bu döngüde bir koşul sağlandığında döngüden çıkılır.
        //Sürekli olarak işlemciyi meşgul eder ve performans kaybına neden olur. Çünkü while döngüsü sürekli olarak çalışır ve işlemciyi meşgul eder.
        bool threadCondition = true;

        Thread thread1 = new(() =>
        {
            while (true)
            {
                if (threadCondition)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine($"Thread 1 {i}");
                    }

                    threadCondition = false;
                    break;
                }
            }
        });

        Thread thread2 = new(() =>
        {
            while (true)
            {
                if (!threadCondition)
                {
                    for (int i = 10; i > 0; i--)
                    {
                        Console.WriteLine($"Thread 2 {i}");
                    }

                    break;
                }
            }
        });

        thread1.Start();
        thread2.Start();
    }
}
#endregion