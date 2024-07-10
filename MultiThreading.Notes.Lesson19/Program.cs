using System.Collections.Concurrent;

#region ConcurrentBag<T>
//// ConcurrentBag<T> thread güvenli bir şekilde eleman eklemek ve çıkarmak için kullanılır. Ayrıca ConcurrentBag<T> sınıfı içerisindeki elemanlar üzerinde işlem yapmak için kullanılır. Concurrent kendi içerisinde locking, senkronizasyon işlemlerini yapar.

//// List<T> ile ConcurrentBag<T> arasındaki farklar: List<T> sınıfı thread safe değildir. ConcurrentBag<T> sınıfı ise thread safe bir sınıftır. List<T> sınıfı üzerinde aynı anda birden fazla işlem yapmaya çalışırsak hata alırız. ConcurrentBag<T> sınıfı üzerinde aynı anda birden fazla işlem yapmaya çalışsak hata almaz.

////Asenkron çalışmalarda herhangi bir sıralama belirtmeksizin işlemler yapılır. Bu nedenle List<T> nazaran ConcurrentBag<T> sınıfı kullanılarak işlemler yapılabilir.

//ConcurrentBag<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Add(i);
//        await Console.Out.WriteLineAsync($"Producer {i.ToString()}");
//        await Task.Delay(50);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    while (true)
//    {
//        // ConcurrentBag<T> sınıfı içerisindeki elemanları çıkarmak için TryTake() metodu kullanılır.
//        if (numbers.TryTake(out int result))
//        {
//            await Console.Out.WriteLineAsync($"Consumer {result}");
//        }
//        else
//        {
//            await Task.Delay(500);
//        }
//    }
//});

//await Task.WhenAny(producer, consumer);

#endregion

#region BlockingCollection<T>
//// BlockingCollection<T> sınıfı şu işe yarar; bir thread bir işlemi yaparken diğer thread bir işlem yapamaz. BlockingCollection<T> sınıfı bu işlemi yaparken diğer thread'lerin işlem yapmasını engeller. BlockingCollection<T> sınıfı içerisindeki elemanlar üzerinde işlem yapmak için kullanılır.

//// BlockingCollection<T> sınıfı içerisindeki elemanlar üzerinde işlem yapmak için Take() metodu kullanılır. Take() metodu eleman çıkartır ve eleman çıkartıldıktan sonra elemanın çıkartılıp çıkartılmadığını kontrol eder. Eğer eleman çıkartıldıysa işlem yapar, çıkartılmadıysa işlem yapmaz.

//BlockingCollection<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Add(i);
//        await Console.Out.WriteLineAsync($"Producer {i.ToString()}");
//        await Task.Delay(500);
//    }

//    //Ekleme işlemi son bulduğunu belirtmek için CompleteAdding() metodu kullanılır.

//    //Ne zaman bu metot çağrılırsa consumer tetiklenir ve işlem yapmaya başlar. (Gerçek queue publisher ve consumer mantığını düşünebiliriz)
//    //Tüm veriler tüketilirse hata fırlatmasını sağlar
//    //CompleteAdding() metodu kullanılmadığında consumer işlem yapmaya devam eder ancak kaynak tüketildiğini anlayamayacağı için hata fırlatmaz. 
//    numbers.CompleteAdding();
//});

//Task consumer = Task.Run(async () =>
//{
//    try
//    {
//        while (true)
//        {
//            //BlockingCollection<T> TryTake () metodu ile eleman çıkartılır. Eğer eleman yoksa işlem yapmaya devam eder.
//            int result = numbers.Take();
//            await Console.Out.WriteLineAsync($"Consumer {result}");
//        }
//    }
//    catch (Exception)
//    {
//        await Console.Out.WriteLineAsync("Kaynak tüketildi...");
//    }
//});

//await Task.WhenAny(producer, consumer);

//Console.ReadLine();
#endregion

#region ConcurrentStack<T>
////ConcurrentStack<T> sınıfı thread güvenli bir şekilde eleman eklemek ve çıkarmak için LIFO (last in first out)mantığı ile haraket eder.

//ConcurrentStack<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Push(i);
//        Console.WriteLine($"Producer {i}");
//        await Task.Delay(100);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    await Task.Delay(3000);

//    while (true)
//    {
//        if (numbers.TryPop(out int result))
//        {
//            Console.WriteLine($"Consumer {result}");
//            await Task.Delay(100);

//        }
//    }
//});

//await Task.WhenAny(producer, consumer);

//Console.ReadLine();
#endregion

#region ConcurrentQueue<T>
////ConcurrentQueue<T> sınıfı thread güvenli bir şekilde eleman eklemek ve çıkarmak için FIFO (first in first out) mantığı ile hareket eder.

//ConcurrentQueue<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Enqueue(i);
//        Console.WriteLine($"Producer {i}");
//        await Task.Delay(100);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    await Task.Delay(3000);

//    while (true)
//    {
//        if (numbers.TryDequeue(out int result))
//        {
//            Console.WriteLine($"Consumer {result}");
//            await Task.Delay(100);

//        }
//    }
//});

//await Task.WhenAny(producer, consumer);

//Console.ReadLine();
#endregion

#region ConcurrentDictionary<TKey, TValue>

ConcurrentDictionary<int,int> numbers = new();
Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        numbers[i] = i * 5;
        Console.WriteLine($"Producer : '{i}' key'ine karşılık '{i*5}' değeri verilmiştir.");
        await Task.Delay(100);
    }
});

Task consumer = Task.Run(async () =>
{
    Task.Delay(1000);
    for (int i = 0; i < 10; i++)
    {
        numbers[i] = i * 5;
        Console.WriteLine($"Consumer : '{i}' key'ine karşılık '{numbers[i]}' değeri okunmuştur.");
        await Task.Delay(300);
    }
});

await Task.WhenAny(producer, consumer);

Console.ReadLine();
#endregion