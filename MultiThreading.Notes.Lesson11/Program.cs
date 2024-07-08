//Örneğin Threadler içerisindeki ilk for döngüleri tamamlansın ve ardından ikinci for döngüleri çalışmasını istiyorsam Barrier sınıfını kullanabilir.
//Barrier sınıfı, belirli sayıda threadin belirli bir noktada birleşmesini beklemek için kullanılır. (Senkranizasyonu sağlar)
//Koşu yarılarındaki koşucuların birleştiği noktayı düşünebiliriz.

//Birinci parametre Kaç tane threadden sinyal bekleyeceğim? bu örnek için 3 threadin sinyalini bekleyecek. Kaç thread varsa o kadar sinyal bekler. sayı önemlidir.
//İkinci parametre ise sinyal bekleyen threadlerin çalıştığı metodu belirtir. (Action metodu)
Barrier barrier = new(3, _ => Console.WriteLine("İkinci for döngüsüne geçiliyor..."));

Thread thread1 = new(() =>
{
    for (int i = 0; i < 5; i++)
        Console.WriteLine($"Thread 1.1: - {i}");

    //Thread 1.1 çalıştıktan sonra diğer threadlerin de çalışmasını beklemek için sinyal veriyoruz.
    //Tüm threadler sinyali aldıktan sonra bir sonraki işleme geçer. (ikinci for döngüsüne geçiş olacaktır)
    barrier.SignalAndWait();

    for (int i = 0; i < 3; i++)
        Console.WriteLine($"Thread 1.2: - {i}");
});

Thread thread2 = new(() =>
{
    for (int i = 0; i < 3; i++)
        Console.WriteLine($"Thread 2.1: - {i}");

    barrier.SignalAndWait();


    for (int i = 0; i < 2; i++)
        Console.WriteLine($"Thread 2.2: - {i}");
});

Thread thread3 = new(() =>
{
    for (int i = 0; i < 4; i++)
        Console.WriteLine($"Thread 3.1: - {i}");

    barrier.SignalAndWait();

    for (int i = 0; i < 5; i++)
        Console.WriteLine($"Thread 3.2: - {i}");
});

thread1.Start();
thread2.Start();
thread3.Start();