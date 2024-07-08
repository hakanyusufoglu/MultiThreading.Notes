#region ThreadStatic Attribute

//Thread local storage (TLS) bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez.
public class Program
{
    //ThreadStatic attribute ile bir field'ın thread local storage olarak işaretlenmesini sağlar. 
    [ThreadStatic]
    static int x = 0;
    private static void Main(string[] args)
    {
        Thread thread1 = new(() =>
        {
            while (x < 10)
                Console.WriteLine($"Thread1 {++x}");
        });

        Thread thread2 = new(() =>
        {
            while (x < 10)
                Console.WriteLine($"Thread2 {++x}");
        });

        Thread thread3 = new(() =>
        {
            while (x < 10)
                Console.WriteLine($"Thread3 {++x}");
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}
#endregion