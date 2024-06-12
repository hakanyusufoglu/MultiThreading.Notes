#region Semophore 
internal class Program
{
    private static void Main(string[] args)
    {
        List<int> numbers = new();

        //Semaphore ortak kaynağı maximum 2 tane thread kullanabilir. Bir thread işlemi bitirince diğer thread işlemi başlar.
        Semaphore semaphore = new(2, 2);

        Thread thread1 = new(() =>
        {
            //Semaphore.WaitOne() metodu ile semaphore nesnesinin sayısını azaltıyoruz.
            semaphore.WaitOne();
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine($"Thread 1 {++i}");
                numbers.Add(i);
                Thread.Sleep(1000);
            }
            //Semaphore.Release() metodu ile semaphore nesnesinin sayısını arttırıyoruz. Yani bir thread işlemi bittiğinde diğer thread işlemi başlar.
            semaphore.Release();
        });

        Thread thread2 = new(() =>
        {
            semaphore.WaitOne();
            int i = 10;

            while (i < 20)
            {
                Console.WriteLine($"Thread 2 {++i}");
                numbers.Add(i);
                Thread.Sleep(1500);
            }

            semaphore.Release();
        });

        Thread thread3 = new(() =>
        {
            semaphore.WaitOne();
            int i = 20;

            while (i < 30)
            {
                Console.WriteLine($"Thread 3 {++i}");
                numbers.Add(i);
                Thread.Sleep(2000);
            }

            semaphore.Release();
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}
#endregion