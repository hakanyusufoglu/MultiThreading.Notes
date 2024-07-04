internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
            new Thread(Read).Start();

        for (int i = 0; i < 2; i++)
            new Thread(Write).Start();


    }
    //ReaderWriteLockSlim: It is used to synchronize the read and write operations. It allows multiple threads to read the shared resource concurrently and only one thread to write the shared resource at a time.

    static ReaderWriterLockSlim readerWriterLockSlim = new();
    static int counter = 0;

    static void Read()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                readerWriterLockSlim.EnterReadLock();
                Console.WriteLine($"R : Thread {Thread.CurrentThread.ManagedThreadId} is reading : {counter}");
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
            Thread.Sleep(1000);
        }
    }

    static void Write()
    {
        try
        { 
            //Kritik nokta
            readerWriterLockSlim.EnterWriteLock();
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine($"W : Thread {Thread.CurrentThread.ManagedThreadId} is wring : {++counter}");
                Thread.Sleep(200);
            }

        }
        finally
        {
            readerWriterLockSlim.ExitWriteLock();
        }
    }
}
