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
Task task = Task.Factory.StartNew(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine(i);
});

Console.Read();
#endregion