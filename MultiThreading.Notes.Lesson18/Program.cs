﻿#region Senkron
//IEnumerable<int> GetNumbers()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Thread.Sleep(1000);
//        yield return i;
//    }
//}

////Maliyet
//foreach (int i in GetNumbers())
//    Console.WriteLine(i);

#endregion

#region Asenkron

//async IAsyncEnumerable<int> GetNumbersAsync()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        await Task.Delay(1000);
//        yield return i;
//    }
//}

//await foreach (int i in GetNumbersAsync())
//    Console.WriteLine(i);

#endregion

#region Custom Example
//Bir sınıfı IAsyncEnumarable yapmak için sınıfın içerisinde bir metot oluşturulur ve bu metot async olarak işaretlenir.

NumberList numbers = new();
await foreach (int number in numbers)
    Console.WriteLine(number);

class NumberList : IAsyncEnumerable<int>
{
    List<int> numbers = new() { 1, 3, 5, 7 };

    public async IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        foreach (var number in numbers)
        {
            await Task.Delay(1000);
            yield return number;
        }
    }
}

#endregion