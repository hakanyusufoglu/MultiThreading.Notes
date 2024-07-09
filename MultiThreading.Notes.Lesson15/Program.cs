#region TaskFactory
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

Task task1 = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine($"Task 1: {i}");
});

Task task2 = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine($"Task 2: {i}");
});

Task task3 = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine($"Task 3: {i}");
});

TaskFactory taskFactory = new();
taskFactory.ContinueWhenAll(new [] { task1, task2, task3 }, tasks =>
{
    Console.WriteLine("All tasks are completed");
});
#endregion
#endregion

Console.Read();