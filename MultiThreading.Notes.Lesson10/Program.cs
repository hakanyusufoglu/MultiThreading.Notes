
#region Thread Pool
//Maximum çalışacak thread sayısını veriyoruz. SetMaxThreads metodu ile ThreadPool içerisindeki thread sayısını belirleyebiliriz.
//Ancak bu duruma işletim sistemi müdahale ettiğinden tam olarak belirlediğimiz miktarda thread çalışmayacaktır. ya daha az ya da daha fazla çalışacaktır.
//ThreadPool.SetMaxThreads(4, 4);
//ThreadPool.SetMinThreads(2, 2);

////Bu metot kullanılarak bir operasyon başlatılır. WorkerMethod metodunu ThreadPooldaki bir thread ile çalıştırılır.
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 1");

//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 2");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 3");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 4");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 5");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 6");
//ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 7");


//Console.Read();
//void WorkerMethod(object state)
//{
//    //Bu metot çalıştırıldığında yapılacak işlemler burada yer alır.

//    //ThreadCount özelliği ile ThreadPool içerisindeki thread sayısını öğrenebiliriz. O anda işlem yapan aktif thread sayısını verir.
//    Console.WriteLine($"*** Thread Count: {ThreadPool.ThreadCount}");

//    string name = (string)state;
//    Console.WriteLine($"{name} işi başladı");
//    Thread.Sleep(new Random().Next(1000, 5000));
//    Console.WriteLine($"{name} işi tamamlandı");
//} 
#endregion

#region RegisterWaitForSingleObject

//// RegisterWaitForSingleObject metodu ile bir thread oluşturulur ve bu thread belirtilen bir zaman sonra çalıştırılır. Thread Pool da singalling davranışını gerçekleştirmesini sağlıyor.

//AutoResetEvent autoResetEvent = new(false);

////timeout süresiz olacak şekilde -1 verilir.
//RegisteredWaitHandle registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(autoResetEvent,WorkerMethod,"Task 1 Wait Handle",-1,true);

////1.5 saniye boyunca set edilmezse otomatik faal hale gelecektir (alttaki thread.sleep ve aytoresetevent.set silinmelidir.)
////RegisteredWaitHandle registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(autoResetEvent,WorkerMethod,"Task 1 Wait Handle",1500,true);

//Thread.Sleep(2500);
//autoResetEvent.Set();

//registeredWaitHandle.Unregister(autoResetEvent);

//Console.Read();
//void WorkerMethod(object state, bool timedOut)
//{
//    //Bu metot çalıştırıldığında yapılacak işlemler burada yer alır.

//    //ThreadCount özelliği ile ThreadPool içerisindeki thread sayısını öğrenebiliriz. O anda işlem yapan aktif thread sayısını verir.
//    Console.WriteLine($"*** Thread Count: {ThreadPool.ThreadCount}");

//    string name = (string)state;
//    Console.WriteLine($"{name} işi başladı");
//    Thread.Sleep(new Random().Next(1000, 5000));
//    Console.WriteLine($"{name} işi tamamlandı");
//}

#endregion

#region WaitHandle.WaitAll & WaitHandle.WaitAny

AutoResetEvent autoResetEvent1 = new(false);
AutoResetEvent autoResetEvent2 = new(false);

ManualResetEvent manualResetEvent1 = new(false);
ManualResetEvent manualResetEvent2 = new(false);

//Tüm eventlerden sinyal aldıktan sonra hello mesajı gelecektir. (WaitAny metodunu test edebilmek için setlerden bir tanesini kaldırabilirsiniz.)
autoResetEvent1.Set();
autoResetEvent2.Set();
manualResetEvent1.Set();
manualResetEvent2.Set();

//WaitHandle.WaitAll metodu ile belirtilen tüm WaitHandle nesneleri set edilene kadar bekler.
//WaitHandle.WaitAny(new WaitHandle[]
//{
//    autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2
//});

WaitHandle.WaitAll(new WaitHandle[]
{
    autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2
});

Console.WriteLine("Hello");
Console.ReadLine();

#endregion