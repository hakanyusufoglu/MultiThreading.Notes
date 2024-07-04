#region Spinlock
internal class Program
{
    //Spinlock: birden fazla thread ile senkronizasyon sağlamak için kullanılır.
    private static void Main(string[] args)
    {
        //Ortak kaynak
        int value = 0;

        SpinLock spinLock = new();


        Thread thread1 = new(() =>
                {
                    bool lackTaken = false;
                    try
                    {
                        spinLock.Enter(ref lackTaken);
                        if (lackTaken)
                            for (int i = 0; i < 999; i++)
                                Console.WriteLine($"Thread1 : {++value}");
                    }
                    finally
                    {
                        spinLock.Exit();
                    }

                });

        Thread thread2 = new(() =>
        {
            bool lackTaken = false;
            try
            {
                spinLock.Enter(ref lackTaken);
                if (lackTaken)
                    for (int i = 0; i < 999; i++)
                        Console.WriteLine($"Thread2 : {value--}");
            }
            finally
            {
                spinLock.Exit();
            }

        });
        thread1.Start();
        thread2.Start();

    }
}
#endregion