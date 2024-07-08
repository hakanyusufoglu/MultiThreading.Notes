#region ThreadStatic Attribute

//Thread local storage (TLS) bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez.
//public class Program
//{
//    //ThreadStatic attribute ile bir field'ın thread local storage olarak işaretlenmesini sağlar. 
//    [ThreadStatic]
//    static int x = 0;
//    private static void Main(string[] args)
//    {
//        Thread thread1 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread1 {++x}");
//        });

//        Thread thread2 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread2 {++x}");
//        });

//        Thread thread3 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread3 {++x}");
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }
//}
#endregion

#region ThreadLocal<T> Class
////Thread local storage (TLS) bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez.
////ThreadLocal<T> sınıfı, bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez. Hem static hem de instance field olarak tanımlanabilir. Örneğin X değişkeni statik değilse bile ThreadLocal<T> sınıfı ile thread local storage olarak işaretlenebilir.

////0 başlangıç değeridir.
//ThreadLocal<int> x = new(() => 0);
//Thread thread1 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread1 {++x.Value}");
//});

//Thread thread2 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread2 {++x.Value}");
//});

//Thread thread3 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread3 {++x.Value}");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion

#region GetData & SetData

internal class Program
{
    static LocalDataStoreSlot localDataStoreSlot = Thread.GetNamedDataSlot("x");
    static int X
    {
        get
        {
            //Slotta verinin olduğunu garanti edemeyeceğimiz için int nullable kullanıyoruz.
            var data = (int?)Thread.GetData(localDataStoreSlot);
            return data is null ? 0 : data.Value;
        }
        set => Thread.SetData(localDataStoreSlot, value);

    }
    private static void Main(string[] args)
    {
        //Thread local storage (TLS) bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez.
        //GetData ve SetData metotları ile thread local storage verilerine erişebiliriz. Property olarak kullanılan bu metotlar, bir threadin kendi verilerini saklamasını sağlar. Ayrıca bu veriler diğer threadler tarafından değiştirilemez.



        Thread thread1 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread1 {++X}");
        });

        Thread thread2 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread2 {++X}");
        });

        Thread thread3 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread3 {++X}");
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}
#endregion