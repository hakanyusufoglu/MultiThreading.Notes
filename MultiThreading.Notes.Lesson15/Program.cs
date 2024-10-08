﻿#region TaskFactory
#region StartNew
//TaskFactory taskFactory = new();
//taskFactory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Task 1: {i}");
//    }
//});

#endregion

#region ContinueWhenAll
//ContinueWhenAll tüm threadler görevlerini tamamladıktan sonra çalışır. ve bu işlemi bir thread üzerinde yapar. Böylece asenkrondur.

//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 1: {i}");
//});

//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 2: {i}");
//});

//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 3: {i}");
//});

//TaskFactory taskFactory = new();
//taskFactory.ContinueWhenAll(new [] { task1, task2, task3 }, tasks =>
//{
//    Console.WriteLine("All tasks are completed");
//});
#endregion

#region ContinueWhenAny
//ContinueWhenAny herhangi bir thread görevini tamamladıktan sonra çalışır. ve bu işlemi bir thread üzerinde yapar. Böylece asenkrondur.

//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 1: {i}");
//});

//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 2: {i}");
//});

//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 3: {i}");
//});

//TaskFactory taskFactory = new();
//taskFactory.ContinueWhenAny(new[] { task1, task2, task3 }, tasks =>
//{
//    Console.WriteLine("...");
//});
#endregion


#endregion

#region TaskScheduler

//TaskScheduler ile taskların nasıl çalışacağını belirleyebiliriz.

//Task.Factory.StartNew(() =>
//{

//},new(), TaskCreationOptions.None, new CustomTaskScheduler());

//class CustomTaskScheduler : TaskScheduler
//{
//    //Planlanmış tasklarla ilgili listeleri tutar.
//    protected override IEnumerable<Task>? GetScheduledTasks() => null;

//    //Tasklarla ilgili planlama işlemi yapar.
//    protected override void QueueTask(Task task) => ThreadPool.QueueUserWorkItem(_ =>
//    {
//        TryExecuteTask(task);
//    });

//    //Task üzerinden deneme yapar.
//    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => true;
//}
#endregion

#region TaskCompletionSource
//TaskCompletionSource ile taskların durumlarını kontrol edebiliriz. 

Task<int> Operation(ResultType resultType)
{
    TaskCompletionSource<int> taskCompletionSource = new();

    switch (resultType)
    {
        case ResultType.Result:
            taskCompletionSource.SetResult(42);
            break;
        case ResultType.Exception:
            taskCompletionSource.SetException(new Exception("An error occured"));
            break;
        case ResultType.Canceled:
            taskCompletionSource.SetCanceled();
            break;
    }

    return taskCompletionSource.Task;
}

var task = Operation(ResultType.Result);

Console.WriteLine(); //Breakpoint koyarak task değişkenini izlenmesi önerilir.
enum ResultType
{
    Result,
    Exception,
    Canceled
}
#endregion
