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
Task task = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine(i);
});

Console.Read();
#endregion