#region New Task
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});
//task.Start();

//Console.Read();
#endregion

#region Task.Run
//Task task = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});

//Console.Read();
#endregion

#region Task.Factory.StartNew
//Task.Factory.StartNew ile birlikte task içerisinde task çalıştırabiliriz. Ancak diğer new Task() ve Task.Run() metodların da çalıştıramayız.
//StartNew de daha fazla parametre alabiliriz. Örneğin TaskCreationOptions, TaskScheduler gibi.
//Genel de Task.Run() kullanılır.

//Task task = Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});

//Console.Read();
#endregion


Task task = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine(i);
});

//Task Methods
#region Start
//Bir task başlatıldıysa tekrar başlatılamaz
//task.Start();
#endregion
#region Wait
//task işlemi bitmesini bekledikten sonra alttaki işlemi gerçekleştirir. Wait() beklemeyi sağlamaktadır.
//task.Wait();
//Console.WriteLine("Merhaba");

//Console.Read();
#endregion
#region ContinueWith
//Wait ile ContinueWith arasındaki fark ise Wait taskın bitmesini bekler sonra kodun devamını getirir. ContinueWith ise Task işlemi biter bitmez bir sonraki çalışacak işlem gibi davranmasını sağlar.

//task.ContinueWith((_task) =>
//{
//    Console.WriteLine("İşlem tamamlandı");
//});
#endregion
#region WaitAll
//Bütün taskların işlemi bittikten sonra ilgili işlem gerçekleştirilsin istiyorsak WaitAll metodu kullanılır

//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i+" task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + " task3");
//});

//Task.WaitAll(task, task2, task3);
//Console.WriteLine("task, task2, task3 bitti. Merhaba");

//Console.ReadLine();
#endregion
#region WhenAll
//Belirtilen taskların tümünün sonucunda bir Task döndürür. 


//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + " task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + " task3");
//});

//Task.WhenAll(task, task2, task3); //farklı bir task yani asenkron gerçekleştiriyor.
//Console.WriteLine("Merhaba");

//Console.ReadLine();
#endregion
#region WaitAny
//WaitAny taskların bir tanesi tamamlandıysa kodu devam ettirir.

//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + " task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + " task3");
//});

//Task.WaitAny(task, task2, task3); //farklı bir task yani asenkron gerçekleştiriyor.
//Console.WriteLine("Merhaba");

//Console.ReadLine();
#endregion
#region WhenAny

//Herhangi bir task tamamlandığında geriye task döndürür

//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + " task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + " task3");
//});

//Task.WhenAny(task, task2, task3); //farklı bir task yani asenkron gerçekleştiriyor.
//Console.WriteLine("Merhaba");

//Console.ReadLine();
#endregion
#region Delay
//Taskın beklemesini sağlamaktadır. Thread.Sleep, threadi direkt bloklar senkrondur. Ancak delay asenkron şekilde gerçekleştirdiği için bloklayamayız. Senkron yapmak için ise await kullanılmaktadır.

//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Task.Delay(1000); //await kullanılmalıdır. (anlatılacak)
//        Console.WriteLine(i);

//    }
//});

#endregion
#region FromCancelled
//Task task2 = Task.Run(() =>
//{
//    //İptal edilmiş task oluşturmuş olduk. Bu task başarısız olduğunu temsil edebiliriz.
//    return Task.FromCanceled(new());
//});

#endregion
#region FromException
//Task task1 = Task.FromException(new("Hata alındı"));
//Console.Read();
#endregion
#region FromResult
//Bu taskın resultı 3 olacak anlamına gelmektedir.

//Task<int> task1 = Task.Run(() => 35);
//Task<int> task2 = Task.Run<int>(() => 3);

//var result = task1.Result; //result = 35
#endregion
#region Yield
//async olmasını sağlar.
#endregion
#region GetAwaiter
// Asenkron süreçlerin senkron olmasını sağlamaktadır. 

Task<int> task1 = Task.Run(() => 3);

//Result kodu senkron hale getirir.
var result = task1.Result;

//GetAwaiter kodu senkron hale getirir. Daha izlenebilir bir kod yapısı sağlar. Daha az maliyetlidir
task1.GetAwaiter().GetResult();
#endregion