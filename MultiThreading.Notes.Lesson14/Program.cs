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


//Task metotlarını denemek için bu kodu yorum satırından kaldırınız.
//Task task = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});

//Methods
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

//Task<int> task1 = Task.Run(() => 3);

////Result kodu senkron hale getirir.
//var result = task1.Result;

////GetAwaiter kodu senkron hale getirir. Daha izlenebilir bir kod yapısı sağlar. Daha az maliyetlidir
//var result2 = task1.GetAwaiter().GetResult();

//Console.Read();
#endregion

//Properties
#region CompletedTask
//Task X()
//{
//    //işlemler...
//    //return Task.Run(()=> { }); //Taskın tamamlandığını belirtir. Taskın başarılı bir şekilde tamamlandığını belirtir.
//    //return Task.Run(()=> { }); //Taskın tamamlandığını belirtir. Taskın başarılı bir şekilde tamamlandığını belirtir.

//    //Taskın tamamlandığını belirtir. Taskın başarılı bir şekilde tamamlandığını belirtir.
//    return Task.CompletedTask; 
//}
#endregion
#region CurrentId
//Taskın id değerini döndürür. 

//Task task = Task.Run(() =>
//{
//    Console.WriteLine($"Task Current Id {Task.CurrentId}");
//});

//Task task2 = Task.Run(() =>
//{
//    Console.WriteLine($"Task-2 Current Id {Task.CurrentId}");
//});
//Console.Read();
#endregion
#region Factory
//Taskın factorysini döndürür. Taskın oluşturulduğu factoryyi döndürür. Factory Nedir? Taskın oluşturulduğu yerdir.
#endregion
#region IsCompleted
//Task tamamlanıp tamamlanmadığını gösterir
#endregion
#region IsCanceled
//Task ,iptal edilip edilmediğini gösterir
#endregion
#region AsyncState
//var task1 = Task.Factory.StartNew((i) =>
//{
//    var _i = (int)i;
//    for (int k = 0; k < _i; k++)
//        Console.WriteLine("Merhaba");

//}, 10); // i nin değeri 10 olarak verdim. Buradaki 10 değerine aslında değer değil de state denir. Bu state değeri taskın içerisindeki metoda parametre olarak verilir.

//var state = task1.AsyncState; //state değeri 10 olacaktır.
//Console.WriteLine($"State: {state}");
//Console.Read();
#endregion
#region IsCompletedSuccessfully
//task başarılı bir şekilde tamamlandı mı tamamlanmadı mı bilgisini verir
#endregion
#region Id
//Taskın id değerini döndürür. Eğer taskın id değeri yoksa null döndürür. CurrentId'den farkı ise CurrentId taskın id değerini döndürürken Id taskın id değerini döndürür.
#endregion
#region IsFaulted
//Taskın hata verip vermediğini gösterir
#endregion
#region Status

//status taskın durumunu belirtir.
Task task2 = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(1000);
        Console.WriteLine(i);

    }
});

TaskStatus? status = null;
while (true) 
{
    if(status!=task2.Status)
    {
        Console.WriteLine(task2.Status);
        status=task2.Status;
    }
}

Console.Read();
#endregion