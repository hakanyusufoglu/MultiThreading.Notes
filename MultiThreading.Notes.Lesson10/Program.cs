
//Maximum çalışacak thread sayısını veriyoruz. SetMaxThreads metodu ile ThreadPool içerisindeki thread sayısını belirleyebiliriz.
//Ancak bu duruma işletim sistemi müdahale ettiğinden tam olarak belirlediğimiz miktarda thread çalışmayacaktır. ya daha az ya da daha fazla çalışacaktır.
ThreadPool.SetMaxThreads(4,4);
ThreadPool.SetMinThreads(2,2);

//Bu metot kullanılarak bir operasyon başlatılır. WorkerMethod metodunu ThreadPooldaki bir thread ile çalıştırılır.
ThreadPool.QueueUserWorkItem(WorkerMethod,"Task 1");
#region Thread Pool
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 2");
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 3");
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 4");
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 5");
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 6");
ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 7");


Console.Read();
void WorkerMethod(object state)
{
    //Bu metot çalıştırıldığında yapılacak işlemler burada yer alır.

    //ThreadCount özelliği ile ThreadPool içerisindeki thread sayısını öğrenebiliriz. O anda işlem yapan aktif thread sayısını verir.
    Console.WriteLine($"*** Thread Count: {ThreadPool.ThreadCount}");

    string name = (string)state;
    Console.WriteLine($"{name} işi başladı");
    Thread.Sleep(new Random().Next(1000, 5000));
    Console.WriteLine($"{name} işi tamamlandı");
} 
#endregion