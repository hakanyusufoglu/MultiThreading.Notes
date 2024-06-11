class Program
{
    //Main Thread
    private static void Main(string[] args)
    {
        //Worker Thread
        Thread thread = new((O) =>
        {
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine($"Worker Thread {i}");
            }
        });

        thread.Start();

        for (int i = 0; i < 99; i++)
        {
            Console.WriteLine($"Main Thread {i}");
        }
    }
}