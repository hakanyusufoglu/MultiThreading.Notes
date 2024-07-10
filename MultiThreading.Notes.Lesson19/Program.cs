﻿using System.Collections.Concurrent;

#region ConcurrnetBag<T>
// ConcurrentBag<T> thread güvenli bir şekilde eleman eklemek ve çıkarmak için kullanılır. Ayrıca ConcurrentBag<T> sınıfı içerisindeki elemanlar üzerinde işlem yapmak için kullanılır. Concurrent kendi içerisinde locking, senkronizasyon işlemlerini yapar.

// List<T> ile ConcurrentBag<T> arasındaki farklar: List<T> sınıfı thread safe değildir. ConcurrentBag<T> sınıfı ise thread safe bir sınıftır. List<T> sınıfı üzerinde aynı anda birden fazla işlem yapmaya çalışırsak hata alırız. ConcurrentBag<T> sınıfı üzerinde aynı anda birden fazla işlem yapmaya çalışsak hata almaz.

//Asenkron çalışmalarda herhangi bir sıralama belirtmeksizin işlemler yapılır. Bu nedenle List<T> nazaran ConcurrentBag<T> sınıfı kullanılarak işlemler yapılabilir.

ConcurrentBag<int> numbers = new();

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        numbers.Add(i);
        await Console.Out.WriteLineAsync($"Producer {i.ToString()}");
        await Task.Delay(50);
    }
});

Task consumer = Task.Run(async () =>
{
    while (true)
    {
        // ConcurrentBag<T> sınıfı içerisindeki elemanları çıkarmak için TryTake() metodu kullanılır.
        if (numbers.TryTake(out int result))
        {
            await Console.Out.WriteLineAsync($"Consumer {result}");
        }
        else
        {
            await Task.Delay(500);
        }
    }
});

await Task.WhenAny(producer, consumer);

#endregion