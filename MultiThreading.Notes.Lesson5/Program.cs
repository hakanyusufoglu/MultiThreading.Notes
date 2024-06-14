internal class Program
{
    private static void Main(string[] args)
    {
        Run();
    }
    //Data registerdaki tutarsızlığı gidermek adına direkt sen veriyi bellekten al demek için volatile keyword'ü kullanılır.
    static int i;
    private static void Run()
    {
        Thread thread1 = new(() =>
        {
            while (true)
            {
                //Bazı durumlarda sadece belirli nokta da volatile kullanmak yeterli olabilir. Çünkü volatile keyword'ü kullanıldığında tüm kod bloğu için geçerli olur. Bu durumda performans kaybı yaşanabilir. Bu durumda sadece belirli bir noktada volatile keyword'ü kullanmak daha mantıklı olabilir.

                //Volatile.Read bellekten okumanın garantisini veriyorum demek. Ve bu durumda tutarsızlık durumu söz konusu olmaz.
                Volatile.Write(ref i, Volatile.Read(ref i) +1);
            }
        });

        Thread thread2 = new(() =>
        {
            while (true)
            {
                //Burada tutarsızlık durumu söz konusu olabilir. Çünkü i değeri sürekli değişiyor. Ve bu da mikroişlemcideki Data Register'ın değerini sürekli değiştirmesine sebep oluyor. esela i değeri 10 iken thread2 i değerini okuyor ve i değeri 10 oluyor. Ardından thread1 i değerini 11 yapıyor. Ve thread2 i değerini 10 olarak tutuyor. Bu durumda thread2 i değeri 10 olarak kaldığı için sonsuza kadar 10 olarak kalabilir. Bu durumda tutarsızlık durumu söz konusu olabilir.

                //Data registerin bellekten daha hızlı olacağı için mikroişlemci gönüllü olarak bellekteki değeri data registeria alır. Ve bu durumda tutarsızlık durumu söz konusu olabilir.

                Console.WriteLine(i);
            }
        });

        Thread thread3 = new(() =>
        {
            while (true)
            {
                Volatile.Write(ref i, Volatile.Read(ref i) - 1);
            }
        });
        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}